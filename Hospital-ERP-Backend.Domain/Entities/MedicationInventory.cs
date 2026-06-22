
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class MedicationInventory
{
    public int Id { get; set; }

    public int MedicationId { get; set; }

    public int Quantity { get; set; }

    public DateOnly ExpiryDate { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Medication Medication { get; set; } = null!;
}
