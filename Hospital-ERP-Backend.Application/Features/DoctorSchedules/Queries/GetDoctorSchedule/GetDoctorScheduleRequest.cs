using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetDoctorSchedule
{
    public record GetDoctorScheduleRequest
        : IRequest<GetDoctorScheduleResponse>
    {
        public int Id { get; set; }
    }
}