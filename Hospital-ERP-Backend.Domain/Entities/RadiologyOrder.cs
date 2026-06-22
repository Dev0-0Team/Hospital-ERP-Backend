namespace Hospital_ERP_Backend.Domain.Entities;

public partial class RadiologyOrder
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public string Type { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime OrderedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Doctor Doctor { get; set; } = null!;

    public Patient Patient { get; set; } = null!;

    public ICollection<RadiologyImage> RadiologyImages { get; set; } = new List<RadiologyImage>();

    public RadiologyReport? RadiologyReport { get; set; }
}
