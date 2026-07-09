using MediatR;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.CreateQueuePriority
{
    
    public record CreateQueuePriorityRequest : IRequest<CreateQueuePriorityResponse>
    {
        public string Name { get; set; } = null!;
        public int Level { get; set; }
    }
}