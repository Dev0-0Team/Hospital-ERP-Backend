using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.UpdateQueuePriority
{
    public class UpdateQueuePriorityService : IRequestHandler<UpdateQueuePriorityRequest, UpdateQueuePriorityResponse>
    {
        private readonly IValidator<UpdateQueuePriorityRequest> _validator;
        private readonly IBaseCommandRepository<QueuePriority> _iQueuePriority;
        private readonly IBaseQueryRepository<QueuePriority> _iQueryQueuePriority;

        public UpdateQueuePriorityService(IValidator<UpdateQueuePriorityRequest> validator, IBaseCommandRepository<QueuePriority> iQueuePriority, IBaseQueryRepository<QueuePriority> iQueryQueuePriority)
        {
            _validator = validator;
            _iQueuePriority = iQueuePriority;
            _iQueryQueuePriority = iQueryQueuePriority;
        }

        public async Task<UpdateQueuePriorityResponse> Handle(UpdateQueuePriorityRequest request, CancellationToken cancellationToken)
        {
            return await UpdateQueuePriorityAsync(request);
        }

   
        private async Task<UpdateQueuePriorityResponse> UpdateQueuePriorityAsync(UpdateQueuePriorityRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            QueuePriority? existingQueuePriority = await _iQueryQueuePriority.GetAsync(request.Id);
            if (existingQueuePriority == null)
            {
                throw new KeyNotFoundException($"Queue priority with Id {request.Id} not found.");
            }

            existingQueuePriority.Name = request.Name;
            existingQueuePriority.Level = request.Level;

            QueuePriority? result = await _iQueuePriority.UpdateAsync(existingQueuePriority);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update queue priority.");
            }

            return new UpdateQueuePriorityResponse
            {
                Id = result.Id,
                Name = result.Name,
                Level = result.Level
            };
        }
    }
}