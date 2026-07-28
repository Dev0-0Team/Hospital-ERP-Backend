using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.CreateAdministrativeStaff
{
    internal class CreateAdministrativeStaffService : 
        IRequestHandler<CreateAdministrativeStaffRequest, CreateAdministrativeStaffResponse>
    {
        private readonly IBaseCommandRepository<AdministrativeStaff> _repository;

        private readonly IBaseQueryRepository<Person> _personRepository;

        private readonly IBaseQueryRepository<Department> _departmentRepository;
        private readonly IValidator<CreateAdministrativeStaffRequest> _validator;

        public CreateAdministrativeStaffService(
            IBaseCommandRepository<AdministrativeStaff> doctorRepository,
            IBaseQueryRepository<Person> personRepository,
            IBaseQueryRepository<Department> departmentRepository,
            IValidator<CreateAdministrativeStaffRequest> validator)
        {
            _repository = doctorRepository;
            _personRepository = personRepository;
            _departmentRepository = departmentRepository;
            _validator = validator;
        }

        public async Task<CreateAdministrativeStaffResponse> Handle(CreateAdministrativeStaffRequest request, CancellationToken cancellationToken)
        {
            return await CreateAdministrativeStaffAsync(request);
        }

        public async Task<CreateAdministrativeStaffResponse> CreateAdministrativeStaffAsync(CreateAdministrativeStaffRequest request)
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

            AdministrativeStaff administrativeStaff = new()
            {
                PersonId = request.PersonId,
                DepartmentId = request.DepartmentId,
                JobTitle = request.JobTitle
            };

            AdministrativeStaff? result =
                await _repository.CreateAsync(administrativeStaff);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to create Doctor.");
            }

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
