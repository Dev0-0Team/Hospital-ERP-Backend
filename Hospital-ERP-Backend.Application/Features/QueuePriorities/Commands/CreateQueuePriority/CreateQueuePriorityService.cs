using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.CreateQueuePriority
{
    internal class CreateQueuePriorityService : IRequestHandler<CreateQueuePriorityRequest, CreateQueuePriorityResponse>
    {
        private readonly IValidator<CreateQueuePriorityRequest> _validator;
        private readonly IBaseCommandRepository<QueuePriority> _iQueuePriority;

        public CreateQueuePriorityService(IValidator<CreateQueuePriorityRequest> validator, IBaseCommandRepository<QueuePriority> iQueuePriority)
        {
            _validator = validator;
            _iQueuePriority = iQueuePriority;
        }

        private async Task<CreateQueuePriorityResponse> CreateQueuePriorityAsync(CreateQueuePriorityRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            QueuePriority queuePriority = new QueuePriority
            {
                Name = request.Name,
                Level = request.Level,
            };

            QueuePriority? result = await _iQueuePriority.CreateAsync(queuePriority);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create queue priority.");
            }

            return new CreateQueuePriorityResponse()
            {
                Id = result.Id,
                Name = result.Name,
                Level = result.Level
            };
        }

        public async Task<CreateQueuePriorityResponse> Handle(CreateQueuePriorityRequest request, CancellationToken cancellationToken)
        {
            return await CreateQueuePriorityAsync(request);
        }
    }
}