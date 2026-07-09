using MediatR;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetAllQueuePriorities
{
  
    public record GetAllQueuePrioritiesRequest : IRequest<IEnumerable<GetAllQueuePrioritiesResponse>>
    {
        public int Page { get; set; }
    }
}