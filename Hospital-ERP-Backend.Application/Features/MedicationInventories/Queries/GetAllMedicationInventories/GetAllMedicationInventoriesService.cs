using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Queries.GetAllMedicationInventories
{
    internal class GetAllMedicationInventoriesService : IRequestHandler<GetAllMedicationInventoriesRequest,
            IEnumerable<GetAllMedicationInventoriesResponse>>
    {
        private readonly IBaseQueryRepository<MedicationInventory> _inventoryQueryRepository;

        private readonly IValidator<GetAllMedicationInventoriesRequest> _validator;

        public GetAllMedicationInventoriesService(IBaseQueryRepository<MedicationInventory> inventoryQueryRepository,
            IValidator<GetAllMedicationInventoriesRequest> validator)
        {
            _inventoryQueryRepository = inventoryQueryRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllMedicationInventoriesResponse>> Handle(GetAllMedicationInventoriesRequest request,
            CancellationToken cancellationToken)
        {
            return await GetAllMedicationInventoriesAsync(request);
        }

        private async Task<IEnumerable<GetAllMedicationInventoriesResponse>> GetAllMedicationInventoriesAsync(GetAllMedicationInventoriesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<MedicationInventory> inventories = await _inventoryQueryRepository.GetAllAsync(request.Page);

            if (inventories == null || !inventories.Any())
            {
                throw new KeyNotFoundException($"No medication inventories found on page {request.Page}.");
            }

            return inventories.Select(x => new GetAllMedicationInventoriesResponse
            {
                Id = x.Id,
                MedicationId = x.MedicationId,
                Quantity = x.Quantity,
                ExpiryDate = x.ExpiryDate
            });
        }
    }
}