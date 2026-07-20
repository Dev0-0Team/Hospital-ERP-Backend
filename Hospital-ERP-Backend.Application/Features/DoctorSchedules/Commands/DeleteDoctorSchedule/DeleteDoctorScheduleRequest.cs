using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.DeleteDoctorSchedule
{
    public record DeleteDoctorScheduleRequest
        : IRequest<bool>
    {
        public int Id { get; set; }
    }
}