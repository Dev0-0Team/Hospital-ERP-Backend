using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.UpdateMedicationInventory
{
    public record UpdateMedicationInventoryRequest : IRequest<UpdateMedicationInventoryResponse>
    {
        public int Id { get; set; }

        public int MedicationId { get; set; }

        public int Quantity { get; set; }

        public DateOnly ExpiryDate { get; set; }
    }
}