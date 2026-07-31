using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.CreateMedicationInventory
{
    internal class CreateMedicationInventoryService : IRequestHandler<CreateMedicationInventoryRequest, CreateMedicationInventoryResponse>
    {
        private readonly IBaseCommandRepository<MedicationInventory> _medicationInventoryRepository;

        private readonly IValidator<CreateMedicationInventoryRequest> _validator;

        public CreateMedicationInventoryService(IBaseCommandRepository<MedicationInventory> medicationInventoryRepository,
            IValidator<CreateMedicationInventoryRequest> validator)
        {
            _medicationInventoryRepository = medicationInventoryRepository;
            _validator = validator;
        }

        public async Task<CreateMedicationInventoryResponse> Handle(CreateMedicationInventoryRequest request, CancellationToken cancellationToken)
        {
            return await CreateMedicationInventoryAsync(request);
        }

        private async Task<CreateMedicationInventoryResponse> CreateMedicationInventoryAsync(CreateMedicationInventoryRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            MedicationInventory medicationInventory = new()
            {
                MedicationId = request.MedicationId,
                Quantity = request.Quantity,
                ExpiryDate = request.ExpiryDate
            };

            MedicationInventory? result = await _medicationInventoryRepository.CreateAsync(medicationInventory);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create medication inventory.");
            }

            return new CreateMedicationInventoryResponse
            {
                Id = result.Id,
                MedicationId = result.MedicationId,
                Quantity = result.Quantity,
                ExpiryDate = result.ExpiryDate
            };
        }
    }
}