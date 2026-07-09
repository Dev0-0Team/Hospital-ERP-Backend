using MediatR;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.DeleteQueuePriority
{
    public record DeleteQueuePriorityRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}