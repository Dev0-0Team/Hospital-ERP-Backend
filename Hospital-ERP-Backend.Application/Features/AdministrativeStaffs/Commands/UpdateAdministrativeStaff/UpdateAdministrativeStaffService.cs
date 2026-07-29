using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.UpdateAdministrativeStaff
{
    internal class UpdateAdministrativeStaffService : IRequestHandler<UpdateAdministrativeStaffRequest, UpdateAdministrativeStaffResponse>
    {
        private readonly IBaseCommandRepository<AdministrativeStaff> _repository;
        private readonly IBaseQueryRepository<Person> _personRepository;
        private readonly IBaseQueryRepository<Department> _departmentRepository;
        private readonly IBaseQueryRepository<AdministrativeStaff> _queryRepository;
        private readonly IValidator<UpdateAdministrativeStaffRequest> _validator;

        public UpdateAdministrativeStaffService(
            IBaseCommandRepository<AdministrativeStaff> doctorRepository,
            IBaseQueryRepository<Person> personRepository,
            IBaseQueryRepository<Department> departmentRepository,
            IBaseQueryRepository<AdministrativeStaff> queryRepository,
            IValidator<UpdateAdministrativeStaffRequest> validator)
        {
            _repository = doctorRepository;
            _personRepository = personRepository;
            _departmentRepository = departmentRepository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<UpdateAdministrativeStaffResponse> Handle(UpdateAdministrativeStaffRequest request, CancellationToken cancellationToken)
        {
            return await UpdateAdministrativeStaffAsync(request);
        }

        private async Task<UpdateAdministrativeStaffResponse> UpdateAdministrativeStaffAsync(UpdateAdministrativeStaffRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Person? person = await _personRepository.GetAsync(request.PersonId);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            Department? department = await _departmentRepository.GetAsync(request.DepartmentId);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with Id {request.DepartmentId} not found.");
            }

            AdministrativeStaff? administrativeStaff = await _queryRepository.GetAsync(request.Id);

            if (administrativeStaff == null)
            {
                throw new KeyNotFoundException($"administrative staff with Id {request.Id} not found.");
            }
            administrativeStaff.PersonId = request.PersonId;
            administrativeStaff.DepartmentId = request.DepartmentId;
            administrativeStaff.JobTitle = request.JobTitle;
            administrativeStaff.UpdatedAt = DateTime.UtcNow;

            AdministrativeStaff? result = await _repository.UpdateAsync(administrativeStaff);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Doctor.");
            }

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