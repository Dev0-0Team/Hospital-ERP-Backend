using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.UpdatePrescription
{
    public class UpdatePrescriptionService : IRequestHandler<UpdatePrescriptionRequest, UpdatePrescriptionResponse>
    {
        private readonly IBaseCommandRepository<Prescription> _repository;
        private readonly IBaseQueryRepository<Prescription> _queryRepository;
        private readonly IValidator<UpdatePrescriptionRequest> _validator;

        public UpdatePrescriptionService(IBaseCommandRepository<Prescription> repository, IBaseQueryRepository<Prescription> queryRepository,
            IValidator<UpdatePrescriptionRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<UpdatePrescriptionResponse> Handle(UpdatePrescriptionRequest request, CancellationToken cancellationToken)
        {
            return await UpdatePrescriptionAsync(request);
        }

        private async Task<UpdatePrescriptionResponse> UpdatePrescriptionAsync(UpdatePrescriptionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Prescription? prescription = await _queryRepository.GetAsync(request.Id);

            if (prescription == null)
            {
                throw new KeyNotFoundException($"Prescription with Id {request.Id} not found.");
            }

            prescription.PatientId = request.PatientId;
            prescription.DoctorId = request.DoctorId;
            prescription.UpdatedAt = DateTime.UtcNow;

            Prescription? result = await _repository.UpdateAsync(prescription);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update prescription.");
            }

            return new UpdatePrescriptionResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                DoctorId = result.DoctorId
            };
        }
    }
}