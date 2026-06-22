

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class MedicalRecord : BaseEntity
{
    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public string Diagnosis { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime VisitDate { get; set; }

    public Doctor Doctor { get; set; } = null!;

    public Patient Patient { get; set; } = null!;
}
