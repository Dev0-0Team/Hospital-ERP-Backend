using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.CreateMedicationInventory
{
    public record CreateMedicationInventoryRequest : IRequest<CreateMedicationInventoryResponse>
    {
        public int MedicationId { get; set; }

        public int Quantity { get; set; }

        public DateOnly ExpiryDate { get; set; }
    }
}