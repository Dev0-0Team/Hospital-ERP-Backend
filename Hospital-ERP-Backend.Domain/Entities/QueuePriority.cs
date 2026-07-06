namespace Hospital_ERP_Backend.Domain.Entities;

public partial class QueuePriority : BaseEntity
{
    public string Name { get; set; } = null!;

    public int Level { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
