using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Queries.GetMedicationInventory
{
    public record GetMedicationInventoryRequest : IRequest<GetMedicationInventoryResponse>
    {
        public int Id { get; set; }
    }
}