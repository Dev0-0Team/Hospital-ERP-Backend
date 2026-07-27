using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.UpdateDoctor
{
    internal class UpdateDoctorService : IRequestHandler<UpdateDoctorRequest, UpdateDoctorResponse>
    {
        private readonly IBaseCommandRepository<Doctor> _commandRepository;
        private readonly IBaseQueryRepository<Doctor> _queryRepository;
        private readonly IBaseQueryRepository<Person> _personRepository;
        private readonly IBaseQueryRepository<Department> _departmentRepository;
        private readonly IBaseQueryRepository<Specialization> _specializationRepository;
        private readonly IValidator<UpdateDoctorRequest> _validator;

        public UpdateDoctorService(
            IBaseCommandRepository<Doctor> commandRepository,
            IBaseQueryRepository<Doctor> queryRepository,
            IValidator<UpdateDoctorRequest> validator,
            IBaseQueryRepository<Person> personRepository,
            IBaseQueryRepository<Department> departmentRepository,
            IBaseQueryRepository<Specialization> specializationRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _personRepository = personRepository;
            _departmentRepository = departmentRepository;
            _specializationRepository = specializationRepository;
            _validator = validator;
        }

        public async Task<UpdateDoctorResponse> Handle(UpdateDoctorRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Doctor? doctor = await _queryRepository.GetAsync(request.Id);

            if (doctor == null)
            {
                throw new KeyNotFoundException($"Doctor with Id {request.Id} not found.");
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

            doctor.PersonId = request.PersonId;
            doctor.DepartmentId = request.DepartmentId;
            doctor.SpecializationId = request.SpecializationId;
            doctor.LicenseNumber = request.LicenseNumber;
            doctor.UpdatedAt = DateTime.UtcNow;

            var result = await _commandRepository.UpdateAsync(doctor);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update doctor.");
            }

            return new UpdateDoctorResponse
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