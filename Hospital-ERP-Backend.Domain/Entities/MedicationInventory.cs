
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class MedicationInventory : BaseEntity
{
    public int MedicationId { get; set; }

    public int Quantity { get; set; }

    public DateOnly ExpiryDate { get; set; }

    public Medication Medication { get; set; } = null!;
}
