using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.CreateQueuePriority
{
    internal class CreateQueuePriorityValidator : AbstractValidator<CreateQueuePriorityRequest>
    {
        public CreateQueuePriorityValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Queue priority name is required.")
                .MaximumLength(50).WithMessage("Queue priority name must not exceed 50 characters.");

            RuleFor(x => x.Level)
                .GreaterThan(0).WithMessage("Queue priority level must be greater than 0.");
        }
    }
}