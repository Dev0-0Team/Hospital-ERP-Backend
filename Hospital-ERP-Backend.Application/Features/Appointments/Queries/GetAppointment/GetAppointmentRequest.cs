using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAppointment
{
    public record GetAppointmentRequest : IRequest<GetAppointmentResponse>
    {
        public int Id { get; set; }
    }
}