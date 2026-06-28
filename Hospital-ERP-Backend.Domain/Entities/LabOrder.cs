

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class LabOrder : BaseEntity
{
    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime OrderedAt { get; set; }

    public Doctor Doctor { get; set; } = null!;

    public ICollection<LabTestResult> LabTestResults { get; set; } = new List<LabTestResult>();

    public Patient Patient { get; set; } = null!;
}
