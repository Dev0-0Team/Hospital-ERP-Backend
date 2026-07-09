namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetQueuePriority
{
    public record GetQueuePriorityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Level { get; set; }
    }
}