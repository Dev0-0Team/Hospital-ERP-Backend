
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Appointment : BaseEntity
{
    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public int PriorityId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = null!;

    public string Type { get; set; } = null!;

    public AppointmentQueue? AppointmentQueue { get; set; }

    public Doctor Doctor { get; set; } = null!;

    public Patient Patient { get; set; } = null!;

    public QueuePriority Priority { get; set; } = null!;
}
