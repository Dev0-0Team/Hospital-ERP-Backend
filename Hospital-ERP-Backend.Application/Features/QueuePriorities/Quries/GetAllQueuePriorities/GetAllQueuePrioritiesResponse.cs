namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetAllQueuePriorities
{
    public record GetAllQueuePrioritiesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Level { get; set; }
    }
}