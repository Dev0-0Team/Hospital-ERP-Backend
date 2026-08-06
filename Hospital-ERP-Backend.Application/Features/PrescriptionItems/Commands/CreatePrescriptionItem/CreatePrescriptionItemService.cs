using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.CreatePrescriptionItem
{
    internal class CreatePrescriptionItemService : IRequestHandler<CreatePrescriptionItemRequest, CreatePrescriptionItemResponse>
    {
        private readonly IBaseCommandRepository<PrescriptionItem> _repository;
        private readonly IValidator<CreatePrescriptionItemRequest> _validator;

        public CreatePrescriptionItemService(
            IBaseCommandRepository<PrescriptionItem> repository,
            IValidator<CreatePrescriptionItemRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreatePrescriptionItemResponse> Handle(
            CreatePrescriptionItemRequest request,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            PrescriptionItem item = new()
            {
                PrescriptionId = request.PrescriptionId,
                MedicationId = request.MedicationId,
                Dosage = request.Dosage,
                Duration = request.Duration,
                Quantity = request.Quantity,
                Instructions = request.Instructions
            };

            var result = await _repository.CreateAsync(item);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Prescription Item.");
            }

            return new CreatePrescriptionItemResponse
            {
                Id = result.Id,
                PrescriptionId = result.PrescriptionId,
                MedicationId = result.MedicationId,
                Dosage = result.Dosage,
                Duration = result.Duration,
                Quantity = result.Quantity,
                Instructions = result.Instructions
            };
        }
    }
}