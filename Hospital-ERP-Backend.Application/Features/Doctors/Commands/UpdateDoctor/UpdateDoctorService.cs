using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.UpdateDoctor
{
    internal class UpdateDoctorService : IRequestHandler<UpdateDoctorRequest, UpdateDoctorResponse>
    {
        private readonly IBaseCommandRepository<Doctor> _commandRepository;
        private readonly IBaseCommandRepository<Person> _personRepository;
        private readonly IBaseCommandRepository<Department> _departmentRepository;
        private readonly IBaseCommandRepository<Specialization> _specializationRepository;
        private readonly IValidator<UpdateDoctorRequest> _validator;

        public UpdateDoctorService(
            IBaseCommandRepository<Doctor> commandRepository,
            IValidator<UpdateDoctorRequest> validator,
            IBaseCommandRepository<Person> personRepository,
            IBaseCommandRepository<Department> departmentRepository,
            IBaseCommandRepository<Specialization> specializationRepository)
        {
            _commandRepository = commandRepository;
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

            Doctor? doctor = await _commandRepository.FindAsync(request.Id);

            if (doctor == null)
            {
                throw new KeyNotFoundException($"Doctor with Id {request.Id} not found.");
            }
            bool person = await _personRepository.IsExistAsync(request.PersonId);

            if (!person)
            {
                throw new KeyNotFoundException(
                    $"Person with Id {request.PersonId} not found.");
            }

            bool department = await _departmentRepository.IsExistAsync(request.DepartmentId);

            if (!department)
            {
                throw new KeyNotFoundException(
                    $"Department with Id {request.DepartmentId} not found.");
            }

            bool specialization = await _specializationRepository.IsExistAsync(request.SpecializationId);

            if (!specialization)
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