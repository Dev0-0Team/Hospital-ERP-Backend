using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.CreatePrescription
{
    public class CreatePrescriptionService : IRequestHandler<CreatePrescriptionRequest, CreatePrescriptionResponse>
    {
        private readonly IBaseCommandRepository<Prescription> _repository;
        private readonly IValidator<CreatePrescriptionRequest> _validator;

        public CreatePrescriptionService(IBaseCommandRepository<Prescription> repository, IValidator<CreatePrescriptionRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreatePrescriptionResponse> Handle(CreatePrescriptionRequest request, CancellationToken cancellationToken)
        {
            return await CreatePrescriptionAsync(request);
        }

        private async Task<CreatePrescriptionResponse> CreatePrescriptionAsync(CreatePrescriptionRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Prescription prescription = new()
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId
            };

            Prescription? result = await _repository.CreateAsync(prescription);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create prescription.");
            }

            return new CreatePrescriptionResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                DoctorId = result.DoctorId
            };
        }
    }
}