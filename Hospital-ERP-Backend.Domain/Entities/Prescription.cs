namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Prescription : BaseEntity
{
    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public Doctor Doctor { get; set; } = null!;

    public Patient Patient { get; set; } = null!;

    public ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();
}
