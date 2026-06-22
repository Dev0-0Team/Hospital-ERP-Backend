
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class ChronicDisease
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string DiseaseName { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
