using Hospital_ERP_Backend.Domain.Enums;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.CreateDoctorSchedule
{
    public record CreateDoctorScheduleRequest
        : IRequest<CreateDoctorScheduleResponse>
    {
        public int DoctorId { get; set; }

        public DoctorScheduleDayOfWeek DayOfWeek { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}