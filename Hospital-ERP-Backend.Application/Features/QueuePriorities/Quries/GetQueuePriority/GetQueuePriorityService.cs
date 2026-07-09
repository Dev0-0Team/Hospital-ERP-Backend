using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetQueuePriority
{
    public class GetQueuePriorityService : IRequestHandler<GetQueuePriorityRequest, GetQueuePriorityResponse>
    {
        private readonly IValidator<GetQueuePriorityRequest> _validator;
        private readonly IBaseQueryRepository<QueuePriority> _iQueuePriority;

        public GetQueuePriorityService(IValidator<GetQueuePriorityRequest> validator, IBaseQueryRepository<QueuePriority> iQueuePriority)
        {
            _validator = validator;
            _iQueuePriority = iQueuePriority;
        }

        private async Task<GetQueuePriorityResponse> GetQueuePriorityAsync(GetQueuePriorityRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var queuePriority = await _iQueuePriority.GetAsync(request.Id);
            if (queuePriority == null)
            {
                throw new KeyNotFoundException($"Queue priority with Id {request.Id} not found.");
            }

            return new GetQueuePriorityResponse
            {
                Id = queuePriority.Id,
                Name = queuePriority.Name,
                Level = queuePriority.Level
            };
        }

        public async Task<GetQueuePriorityResponse> Handle(GetQueuePriorityRequest request, CancellationToken cancellationToken)
        {
            return await GetQueuePriorityAsync(request);
        }
    }
}