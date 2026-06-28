
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class EmergencyCase
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string Status { get; set; } = null!;

    public string TriageColor { get; set; } = null!;

    public DateTime ArrivalTime { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Patient Patient { get; set; } = null!;
}
