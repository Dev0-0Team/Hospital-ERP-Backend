using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.CreateDoctor
{
    internal class CreateDoctorService : IRequestHandler<CreateDoctorRequest, CreateDoctorResponse>
    {
        private readonly IBaseCommandRepository<Doctor> _doctorRepository;

        private readonly IBaseQueryRepository<Person> _personRepository;

        private readonly IBaseQueryRepository<Department> _departmentRepository;

        private readonly IBaseQueryRepository<Specialization> _specializationRepository;

        private readonly IValidator<CreateDoctorRequest> _validator;

        public CreateDoctorService(
            IBaseCommandRepository<Doctor> doctorRepository,
            IBaseQueryRepository<Person> personRepository,
            IBaseQueryRepository<Department> departmentRepository,
            IBaseQueryRepository<Specialization> specializationRepository,
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

            Person? person =
                await _personRepository.GetAsync(request.PersonId);

            if (person == null)
            {
                throw new KeyNotFoundException(
                    $"Person with Id {request.PersonId} not found.");
            }

            Department? department =
                await _departmentRepository.GetAsync(request.DepartmentId);

            if (department == null)
            {
                throw new KeyNotFoundException(
                    $"Department with Id {request.DepartmentId} not found.");
            }

            Specialization? specialization =
                await _specializationRepository.GetAsync(request.SpecializationId);

            if (specialization == null)
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