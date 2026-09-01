using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.CreateAdministrativeStaff
{
    internal class CreateAdministrativeStaffService : 
        IRequestHandler<CreateAdministrativeStaffRequest, CreateAdministrativeStaffResponse>
    {
        private readonly IBaseCommandRepository<AdministrativeStaff> _repository;
        private readonly IBaseCommandRepository<Person> _personRepository;
        private readonly IBaseCommandRepository<Department> _departmentRepository;
        private readonly IValidator<CreateAdministrativeStaffRequest> _validator;
        private readonly ILogger<CreateAdministrativeStaffService> _logger;

        public CreateAdministrativeStaffService(
            IBaseCommandRepository<AdministrativeStaff> doctorRepository,
            IBaseCommandRepository<Person> personRepository,
            IBaseCommandRepository<Department> departmentRepository,
            IValidator<CreateAdministrativeStaffRequest> validator,
            ILogger<CreateAdministrativeStaffService> logger)
        {
            _repository = doctorRepository;
            _personRepository = personRepository;
            _departmentRepository = departmentRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<CreateAdministrativeStaffResponse> Handle(CreateAdministrativeStaffRequest request, CancellationToken cancellationToken)
        {
            return await CreateAdministrativeStaffAsync(request);
        }

        private async Task<CreateAdministrativeStaffResponse> CreateAdministrativeStaffAsync(CreateAdministrativeStaffRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning(
                    $"Validation failed while creating administrative staff for Person {request.PersonId}");

                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool person = await _personRepository.IsExistAsync(request.PersonId);

            if (!person)
            {
                _logger.LogWarning(
                    $"Person {request.PersonId} not found while creating administrative staff");

                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            bool department = await _departmentRepository.IsExistAsync(request.DepartmentId);

            if (!department)
            {
                _logger.LogWarning(
                    $"Department {request.DepartmentId} not found while creating administrative staff");

                throw new KeyNotFoundException($"Department with Id {request.DepartmentId} not found.");
            }

            AdministrativeStaff administrativeStaff = new()
            {
                PersonId = request.PersonId,
                DepartmentId = request.DepartmentId,
                JobTitle = request.JobTitle
            };

            AdministrativeStaff? result = await _repository.CreateAsync(administrativeStaff);

            if (result == null)
            {
                _logger.LogWarning(
                    $"Failed to create Administrative Staff for Person {request.PersonId}");

                throw new InvalidOperationException("Failed to create Administrative Staff.");
            }

            _logger.LogInformation(
                $"Administrative staff {result.Id} created successfully for Person {result.PersonId}");

            return new CreateAdministrativeStaffResponse
            {
                Id = result.Id,
                PersonId = result.PersonId,
                DepartmentId = result.DepartmentId,
                JobTitle = result.JobTitle
            };
        }
    }
}
