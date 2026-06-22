namespace Hospital_ERP_Backend.Domain.Entities;

public partial class PrescriptionItem
{
    public int Id { get; set; }

    public int PrescriptionId { get; set; }

    public int MedicationId { get; set; }

    public string Dosage { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public int Quantity { get; set; }

    public string? Instructions { get; set; }

    public Medication Medication { get; set; } = null!;

    public Prescription Prescription { get; set; } = null!;
}
