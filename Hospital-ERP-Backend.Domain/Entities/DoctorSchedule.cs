
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class DoctorSchedule
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public Doctor Doctor { get; set; } = null!;
}
