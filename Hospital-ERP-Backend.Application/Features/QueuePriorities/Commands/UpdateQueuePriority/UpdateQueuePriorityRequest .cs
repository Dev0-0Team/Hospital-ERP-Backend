using MediatR;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.UpdateQueuePriority
{

    public record UpdateQueuePriorityRequest : IRequest<UpdateQueuePriorityResponse>
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public int Level { get; init; }
    }
}