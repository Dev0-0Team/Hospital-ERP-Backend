using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Queries.GetMedicationInventory
{
    public class GetMedicationInventoryService : IRequestHandler<GetMedicationInventoryRequest, GetMedicationInventoryResponse>
    {
        private readonly IBaseQueryRepository<MedicationInventory> _medicationInventory;

        private readonly IValidator<GetMedicationInventoryRequest> _validator;

        public GetMedicationInventoryService(IBaseQueryRepository<MedicationInventory> medicationInventory,
            IValidator<GetMedicationInventoryRequest> validator)
        {
            _medicationInventory = medicationInventory;
            _validator = validator;
        }

        public async Task<GetMedicationInventoryResponse> Handle(GetMedicationInventoryRequest request, CancellationToken cancellationToken)
        {
            return await GetMedicationInventoryAsync(request);
        }

        private async Task<GetMedicationInventoryResponse> GetMedicationInventoryAsync(GetMedicationInventoryRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            MedicationInventory? medicationInventory = await _medicationInventory.GetAsync(request.Id);

            if (medicationInventory == null)
            {
                throw new KeyNotFoundException($"Medication Inventory with Id {request.Id} not found.");
            }

            return new GetMedicationInventoryResponse
            {
                Id = medicationInventory.Id,
                MedicationId = medicationInventory.MedicationId,
                Quantity = medicationInventory.Quantity,
                ExpiryDate = medicationInventory.ExpiryDate
            };
        }
    }
}