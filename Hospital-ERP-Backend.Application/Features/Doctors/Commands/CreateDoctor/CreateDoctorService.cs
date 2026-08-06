using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.CreateDoctor
{
    internal class CreateDoctorService : IRequestHandler<CreateDoctorRequest, CreateDoctorResponse>
    {
        private readonly IBaseCommandRepository<Doctor> _doctorRepository;

        private readonly IBaseCommandRepository<Person> _personRepository;

        private readonly IBaseCommandRepository<Department> _departmentRepository;

        private readonly IBaseCommandRepository<Specialization> _specializationRepository;

        private readonly IValidator<CreateDoctorRequest> _validator;

        public CreateDoctorService(
            IBaseCommandRepository<Doctor> doctorRepository,
            IBaseCommandRepository<Person> personRepository,
            IBaseCommandRepository<Department> departmentRepository,
            IBaseCommandRepository<Specialization> specializationRepository,
            IValidator<CreateDoctorRequest> validator)
        {
            _doctorRepository = doctorRepository;
            _personRepository = personRepository;
            _departmentRepository = departmentRepository;
            _specializationRepository = specializationRepository;
            _validator = validator;
        }

        public async Task<CreateDoctorResponse> Handle(CreateDoctorRequest request, CancellationToken cancellationToken)
        {
            return await CreateDoctorAsync(request);
        }

        public async Task<CreateDoctorResponse> CreateDoctorAsync(CreateDoctorRequest request)
        {


            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool person =
                await _personRepository.IsExistAsync(request.PersonId);

            if (!person)
            {
                throw new KeyNotFoundException(
                    $"Person with Id {request.PersonId} not found.");
            }

            bool department =
                await _departmentRepository.IsExistAsync(request.DepartmentId);

            if (!department)
            {
                throw new KeyNotFoundException(
                    $"Department with Id {request.DepartmentId} not found.");
            }

            bool specialization =
                await _specializationRepository.IsExistAsync(request.SpecializationId);

            if (!specialization)
            {
                throw new KeyNotFoundException(
                    $"Specialization with Id {request.SpecializationId} not found.");
            }

            Doctor doctor = new()
            {
                PersonId = request.PersonId,
                DepartmentId = request.DepartmentId,
                SpecializationId = request.SpecializationId,
                LicenseNumber = request.LicenseNumber
            };

            Doctor? result =
                await _doctorRepository.CreateAsync(doctor);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to create Doctor.");
            }

            return new CreateDoctorResponse
            {
                Id = result.Id,
                PersonId = result.PersonId,
                DepartmentId = result.DepartmentId,
                SpecializationId = result.SpecializationId,
                LicenseNumber = result.LicenseNumber
            };
        }
    }

}