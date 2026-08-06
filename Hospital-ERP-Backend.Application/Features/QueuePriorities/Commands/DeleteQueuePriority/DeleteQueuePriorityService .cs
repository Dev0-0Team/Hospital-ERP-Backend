using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.DeleteQueuePriority
{
    internal class DeleteQueuePriorityService : IRequestHandler<DeleteQueuePriorityRequest, bool>
    {
        private readonly IValidator<DeleteQueuePriorityRequest> _validator;
        private readonly IBaseCommandRepository<QueuePriority> _iQueuePriority;

        public DeleteQueuePriorityService(IValidator<DeleteQueuePriorityRequest> validator, IBaseCommandRepository<QueuePriority> iQueuePriority)
        {
            _validator = validator;
            _iQueuePriority = iQueuePriority;
        }

   
        private async Task<bool> DeleteQueuePriorityAsync(DeleteQueuePriorityRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool queuePriority = await _iQueuePriority.IsExistAsync(request.Id);
            if (!queuePriority)
            {
                throw new KeyNotFoundException($"Queue priority with Id {request.Id} not found.");
            }

            var isDeleted = await _iQueuePriority.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete queue priority with Id {request.Id}.");
            }

            return isDeleted;
        }

        public async Task<bool> Handle(DeleteQueuePriorityRequest request, CancellationToken cancellationToken)
        {
            return await DeleteQueuePriorityAsync(request);
        }
    }
}