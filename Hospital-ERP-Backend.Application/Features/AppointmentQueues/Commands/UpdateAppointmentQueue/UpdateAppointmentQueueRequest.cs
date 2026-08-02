using Hospital_ERP_Backend.Domain.Enums;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.UpdateAppointmentQueue
{
    public record UpdateAppointmentQueueRequest : IRequest<UpdateAppointmentQueueResponse>
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public int QueueNumber { get; set; }

        public DateTime EstimatedTime { get; set; }

        public AppointmentQueueStatus Status { get; set; }
    }
}