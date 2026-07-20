using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorService : IRequestHandler<UpdateDoctorRequest, UpdateDoctorResponse>
    {
        private readonly IBaseCommandRepository<Doctor> _commandRepository;
        private readonly IBaseQueryRepository<Doctor> _queryRepository;
        private readonly IValidator<UpdateDoctorRequest> _validator;

        public UpdateDoctorService(
            IBaseCommandRepository<Doctor> commandRepository,
            IBaseQueryRepository<Doctor> queryRepository,
            IValidator<UpdateDoctorRequest> validator)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
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