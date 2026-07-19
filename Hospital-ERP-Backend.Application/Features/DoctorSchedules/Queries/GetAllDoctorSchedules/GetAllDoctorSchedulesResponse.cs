namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetAllDoctorSchedules
{
    public record GetAllDoctorSchedulesResponse
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public string DayOfWeek { get; set; } = string.Empty;

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}