
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class AppointmentQueue
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }

    public int QueueNumber { get; set; }

    public DateTime EstimatedTime { get; set; }

    public string Status { get; set; } = null!;

    public Appointment Appointment { get; set; } = null!;
}
