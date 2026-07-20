using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.CreateDoctorSchedule
{
    public record CreateDoctorScheduleRequest
        : IRequest<CreateDoctorScheduleResponse>
    {
        public int DoctorId { get; set; }

        public string DayOfWeek { get; set; } = string.Empty;

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}