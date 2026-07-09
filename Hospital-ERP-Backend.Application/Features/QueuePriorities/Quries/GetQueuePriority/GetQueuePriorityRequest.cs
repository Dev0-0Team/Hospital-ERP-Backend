using MediatR;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetQueuePriority
{
    public record GetQueuePriorityRequest : IRequest<GetQueuePriorityResponse>
    {
        public int Id { get; set; }
    }
}