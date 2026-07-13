using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.UpdatePrescriptionItem
{
    public class UpdatePrescriptionItemService : IRequestHandler<UpdatePrescriptionItemRequest, UpdatePrescriptionItemResponse>
    {
        private readonly IValidator<UpdatePrescriptionItemRequest> _validator;

        private readonly IBaseCommandRepository<PrescriptionItem> _repository;

        private readonly IBaseQueryRepository<PrescriptionItem> _queryRepository;

        public UpdatePrescriptionItemService(
            IValidator<UpdatePrescriptionItemRequest> validator,
            IBaseCommandRepository<PrescriptionItem> repository,
            IBaseQueryRepository<PrescriptionItem> queryRepository)
        {
            _validator = validator;
            _repository = repository;
            _queryRepository = queryRepository;
        }

        public async Task<UpdatePrescriptionItemResponse> Handle(
            UpdatePrescriptionItemRequest request,
            CancellationToken cancellationToken)
        {
            return await UpdatePrescriptionItemAsync(request);
        }

        private async Task<UpdatePrescriptionItemResponse> UpdatePrescriptionItemAsync(
            UpdatePrescriptionItemRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            PrescriptionItem? item =
                await _queryRepository.GetAsync(request.Id);

            if (item == null)
            {
                throw new KeyNotFoundException(
                    $"Prescription Item with Id {request.Id} not found.");
            }

            item.PrescriptionId = request.PrescriptionId;
            item.MedicationId = request.MedicationId;
            item.Dosage = request.Dosage;
            item.Duration = request.Duration;
            item.Quantity = request.Quantity;
            item.Instructions = request.Instructions;
            item.UpdatedAt = DateTime.UtcNow;

            PrescriptionItem? result =
                await _repository.UpdateAsync(item);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to update Prescription Item.");
            }

            return new UpdatePrescriptionItemResponse
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