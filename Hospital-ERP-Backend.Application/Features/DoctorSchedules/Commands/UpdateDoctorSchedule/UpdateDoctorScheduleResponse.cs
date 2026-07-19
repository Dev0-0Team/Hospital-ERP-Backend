namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.UpdateDoctorSchedule
{
    public record UpdateDoctorScheduleResponse
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public string DayOfWeek { get; set; } = string.Empty;

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}