using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.DeleteMedicationInventory
{
    public record DeleteMedicationInventoryRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}