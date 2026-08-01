using Hospital_ERP_Backend.Domain.Enums;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.CreateAppointmentQueue
{
    public record CreateAppointmentQueueRequest : IRequest<CreateAppointmentQueueResponse>
    {
        public int AppointmentId { get; set; }

        public int QueueNumber { get; set; }

        public DateTime EstimatedTime { get; set; }
        
        public AppointmentQueueStatus Status { get; set; } = AppointmentQueueStatus.Waiting;
    }
}