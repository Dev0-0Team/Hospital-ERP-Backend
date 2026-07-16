using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.DeleteAppointmentQueue
{
    public record DeleteAppointmentQueueRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}