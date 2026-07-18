namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.CreateAppointmentQueue
{
    public record CreateAppointmentQueueResponse
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public int QueueNumber { get; set; }

        public DateTime EstimatedTime { get; set; }

        public string Status { get; set; } = null!;
    }
}