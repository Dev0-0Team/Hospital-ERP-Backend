using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.UpdateQueuePriority
{
   
    internal class UpdateQueuePriorityValidator : AbstractValidator<UpdateQueuePriorityRequest>
    {
        public UpdateQueuePriorityValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Level)
                .GreaterThan(0).WithMessage("Queue priority level must be greater than 0.");
        }
    }
}