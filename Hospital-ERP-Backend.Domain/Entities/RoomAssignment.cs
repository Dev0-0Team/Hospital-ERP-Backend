namespace Hospital_ERP_Backend.Domain.Entities;

public partial class RoomAssignment
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int BedId { get; set; }

    public DateTime AdmittedAt { get; set; }

    public DateTime? DischargedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Bed Bed { get; set; } = null!;

    public Patient Patient { get; set; } = null!;
}
