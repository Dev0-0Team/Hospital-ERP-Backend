

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class DrugInteraction
{
    public int Id { get; set; }

    public int Medication1Id { get; set; }

    public int Medication2Id { get; set; }

    public string Severity { get; set; } = null!;

    public string Warning { get; set; } = null!;

    public Medication Medication1 { get; set; } = null!;

    public Medication Medication2 { get; set; } = null!;
}
