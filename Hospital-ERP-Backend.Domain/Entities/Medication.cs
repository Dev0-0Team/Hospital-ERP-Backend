

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Medication : BaseEntity
{
    public string Name { get; set; } = null!;

    public string DosageForm { get; set; } = null!;

    public string? Manufacturer { get; set; }

    public ICollection<DrugInteraction> DrugInteractionMedication1s { get; set; } = new List<DrugInteraction>();

    public ICollection<DrugInteraction> DrugInteractionMedication2s { get; set; } = new List<DrugInteraction>();

    public ICollection<MedicationInventory> MedicationInventories { get; set; } = new List<MedicationInventory>();

    public ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();
}
