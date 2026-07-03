
namespace Hospital_ERP_Backend.Domain.Entities;
public partial class Allergy : BaseEntity
{
    public int PatientId { get; set; }

    public string AllergyName { get; set; } = null!;

    public string Severity { get; set; } = null!;

    public Patient Patient { get; set; } = null!;
}
