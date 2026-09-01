using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.UpdateAdministrativeStaff
{
    internal class UpdateAdministrativeStaffService :
        IRequestHandler<UpdateAdministrativeStaffRequest, UpdateAdministrativeStaffResponse>
    {
        private readonly IBaseCommandRepository<AdministrativeStaff> _repository;
        private readonly IBaseCommandRepository<Person> _personRepository;
        private readonly IBaseCommandRepository<Department> _departmentRepository;
        private readonly IValidator<UpdateAdministrativeStaffRequest> _validator;
        private readonly ILogger<UpdateAdministrativeStaffService> _logger;

        public UpdateAdministrativeStaffService(
            IBaseCommandRepository<AdministrativeStaff> doctorRepository,
            IBaseCommandRepository<Person> personRepository,
            IBaseCommandRepository<Department> departmentRepository,
            IValidator<UpdateAdministrativeStaffRequest> validator,
            ILogger<UpdateAdministrativeStaffService> logger)
        {
            _repository = doctorRepository;
            _personRepository = personRepository;
            _departmentRepository = departmentRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<UpdateAdministrativeStaffResponse> Handle(UpdateAdministrativeStaffRequest request,
            CancellationToken cancellationToken)
        {
            return await UpdateAdministrativeStaffAsync(request);
        }

        private async Task<UpdateAdministrativeStaffResponse> UpdateAdministrativeStaffAsync(
            UpdateAdministrativeStaffRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning(
                    "Validation failed while updating Administrative Staff {AdministrativeStaffId}",
                    request.Id);

                throw new ArgumentException(
                    string.Join(", ",
                        validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool person = await _personRepository.IsExistAsync(request.PersonId);

            if (!person)
            {
                _logger.LogWarning(
                    "Person {PersonId} not found while updating Administrative Staff {AdministrativeStaffId}",
                    request.PersonId,
                    request.Id);

                throw new KeyNotFoundException(
                    $"Person with Id {request.PersonId} not found.");
            }

            bool department = await _departmentRepository.IsExistAsync(request.DepartmentId);

            if (!department)
            {
                _logger.LogWarning(
                    "Department {DepartmentId} not found while updating Administrative Staff {AdministrativeStaffId}",
                    request.DepartmentId,
                    request.Id);

                throw new KeyNotFoundException(
                    $"Department with Id {request.DepartmentId} not found.");
            }

            AdministrativeStaff? administrativeStaff =
                await _repository.FindAsync(request.Id);

            if (administrativeStaff == null)
            {
                _logger.LogWarning(
                    "Administrative Staff {AdministrativeStaffId} not found while updating",
                    request.Id);

                throw new KeyNotFoundException(
                    $"Administrative Staff with Id {request.Id} not found.");
            }

            administrativeStaff.PersonId = request.PersonId;
            administrativeStaff.DepartmentId = request.DepartmentId;
            administrativeStaff.JobTitle = request.JobTitle;
            administrativeStaff.UpdatedAt = DateTime.UtcNow;

            AdministrativeStaff? result =
                await _repository.UpdateAsync(administrativeStaff);

            if (result == null)
            {
                _logger.LogWarning(
                    "Failed to update Administrative Staff {AdministrativeStaffId}",
                    request.Id);

                throw new InvalidOperationException(
                    $"Failed to update Administrative Staff with Id {request.Id}.");
            }

            _logger.LogInformation(
                "Administrative Staff {AdministrativeStaffId} updated successfully",
                result.Id);

            return new UpdateAdministrativeStaffResponse
            {
                Id = result.Id,
                PersonId = result.PersonId,
                DepartmentId = result.DepartmentId,
                JobTitle = result.JobTitle
            };
        }
    }
}