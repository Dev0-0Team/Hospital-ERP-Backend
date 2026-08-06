using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.DeleteMedicationInventory
{
    internal class DeleteMedicationInventoryService : IRequestHandler<DeleteMedicationInventoryRequest, bool>
    {
        private readonly IValidator<DeleteMedicationInventoryRequest> _validator;

        private readonly IBaseCommandRepository<MedicationInventory> _repository;

        private readonly IBaseQueryRepository<MedicationInventory> _queryRepository;

        public DeleteMedicationInventoryService(IValidator<DeleteMedicationInventoryRequest> validator, IBaseCommandRepository<MedicationInventory> repository,
            IBaseQueryRepository<MedicationInventory> queryRepository)
        {
            _validator = validator;
            _repository = repository;
            _queryRepository = queryRepository;
        }

        public async Task<bool> Handle(DeleteMedicationInventoryRequest request, CancellationToken cancellationToken)
        {
            return await DeleteMedicationInventoryAsync(request);
        }

        private async Task<bool> DeleteMedicationInventoryAsync(DeleteMedicationInventoryRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            MedicationInventory? inventory = await _queryRepository.GetAsync(request.Id);

            if (inventory == null)
            {
                throw new KeyNotFoundException($"Medication Inventory with Id {request.Id} not found.");
            }

            var isDeleted = await _repository.DeleteAsync(inventory.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete Medication Inventory with Id {request.Id}.");
            }


            return isDeleted;
        }
    }
}