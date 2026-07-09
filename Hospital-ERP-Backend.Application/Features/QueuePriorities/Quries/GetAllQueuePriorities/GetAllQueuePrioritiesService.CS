using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetAllQueuePriorities
{
    public class GetAllQueuePrioritiesService : IRequestHandler<GetAllQueuePrioritiesRequest, IEnumerable<GetAllQueuePrioritiesResponse>>
    {
        private readonly IValidator<GetAllQueuePrioritiesRequest> _validator;
        private readonly IBaseQueryRepository<QueuePriority> _iQueuePriority;

        public GetAllQueuePrioritiesService(IValidator<GetAllQueuePrioritiesRequest> validator, IBaseQueryRepository<QueuePriority> iQueuePriority)
        {
            _validator = validator;
            _iQueuePriority = iQueuePriority;
        }

  
        private async Task<IEnumerable<GetAllQueuePrioritiesResponse>> GetAllQueuePrioritiesAsync(GetAllQueuePrioritiesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var queuePriorities = await _iQueuePriority.GetAllAsync(request.Page);
            if (queuePriorities == null || queuePriorities.Count() == 0)
            {
                throw new KeyNotFoundException($"No queue priorities found on page {request.Page}.");
            }

            return queuePriorities.Select(q => new GetAllQueuePrioritiesResponse
            {
                Id = q.Id,
                Name = q.Name,
                Level = q.Level
            });
        }

        public async Task<IEnumerable<GetAllQueuePrioritiesResponse>> Handle(GetAllQueuePrioritiesRequest request, CancellationToken cancellationToken)
        {
            return await GetAllQueuePrioritiesAsync(request);
        }
    }
}