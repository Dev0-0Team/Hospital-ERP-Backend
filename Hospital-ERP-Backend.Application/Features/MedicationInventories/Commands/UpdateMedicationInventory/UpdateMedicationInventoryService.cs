using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.UpdateMedicationInventory
{
    public class UpdateMedicationInventoryService : IRequestHandler<UpdateMedicationInventoryRequest, UpdateMedicationInventoryResponse>
    {
        private readonly IValidator<UpdateMedicationInventoryRequest> _validator;

        private readonly IBaseCommandRepository<MedicationInventory> _medicationInventoryRepository;

        private readonly IBaseQueryRepository<MedicationInventory> _medicationInventoryQueryRepository;

        public UpdateMedicationInventoryService(IValidator<UpdateMedicationInventoryRequest> validator,
            IBaseCommandRepository<MedicationInventory> medicationInventoryRepository,
            IBaseQueryRepository<MedicationInventory> medicationInventoryQueryRepository)
        {
            _validator = validator;
            _medicationInventoryRepository = medicationInventoryRepository;
            _medicationInventoryQueryRepository = medicationInventoryQueryRepository;
        }

        public async Task<UpdateMedicationInventoryResponse> Handle(UpdateMedicationInventoryRequest request, CancellationToken cancellationToken)
        {
            return await UpdateMedicationInventoryAsync(request);
        }

        private async Task<UpdateMedicationInventoryResponse> UpdateMedicationInventoryAsync(UpdateMedicationInventoryRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            MedicationInventory? medicationInventory = await _medicationInventoryQueryRepository.GetAsync(request.Id);

            if (medicationInventory == null)
            {
                throw new KeyNotFoundException($"Medication Inventory with Id {request.Id} not found.");
            }

            medicationInventory.MedicationId = request.MedicationId;
            medicationInventory.Quantity = request.Quantity;
            medicationInventory.ExpiryDate = request.ExpiryDate;
            medicationInventory.UpdatedAt = DateTime.UtcNow;

            MedicationInventory? result = await _medicationInventoryRepository.UpdateAsync(medicationInventory);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Medication Inventory.");
            }

            return new UpdateMedicationInventoryResponse
            {
                Id = result.Id,
                MedicationId = result.MedicationId,
                Quantity = result.Quantity,
                ExpiryDate = result.ExpiryDate
            };
        }
    }
}