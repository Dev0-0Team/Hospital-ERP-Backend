namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.CreateQueuePriority
{
    public record CreateQueuePriorityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Level { get; set; }
    }
}