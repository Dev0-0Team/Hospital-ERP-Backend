using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.UpdateQueuePriority
{
    internal class UpdateQueuePriorityService : IRequestHandler<UpdateQueuePriorityRequest, UpdateQueuePriorityResponse>
    {
        private readonly IValidator<UpdateQueuePriorityRequest> _validator;
        private readonly IBaseCommandRepository<QueuePriority> _iQueuePriority;

        public UpdateQueuePriorityService(IValidator<UpdateQueuePriorityRequest> validator, IBaseCommandRepository<QueuePriority> iQueuePriority)
        {
            _validator = validator;
            _iQueuePriority = iQueuePriority;
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

            QueuePriority? existingQueuePriority = await _iQueuePriority.FindAsync(request.Id);
            if (existingQueuePriority == null)
            {
                throw new KeyNotFoundException($"Queue priority with Id {request.Id} not found.");
            }

            existingQueuePriority.Name = request.Name;
            existingQueuePriority.Level = request.Level;
            existingQueuePriority.UpdatedAt = DateTime.UtcNow;

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