using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Commands.DeleteAppointment
{
    public record DeleteAppointmentRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}