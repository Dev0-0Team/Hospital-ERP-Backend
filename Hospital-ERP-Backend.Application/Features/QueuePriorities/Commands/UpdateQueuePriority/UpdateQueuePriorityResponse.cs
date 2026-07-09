namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.UpdateQueuePriority
{
    public record UpdateQueuePriorityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Level { get; set; }
    }
}