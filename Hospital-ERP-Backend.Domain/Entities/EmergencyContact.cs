

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class EmergencyContact
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Relationship { get; set; } = null!;

    public Patient Patient { get; set; } = null!;
}
