using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Queries.GetAppointmentQueue
{
    public record GetAppointmentQueueRequest : IRequest<GetAppointmentQueueResponse>
    {
        public int Id { get; set; }
    }
}