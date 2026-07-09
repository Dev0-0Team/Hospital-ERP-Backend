using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Commands.DeleteQueuePriority
{
    public class DeleteQueuePriorityValidator : AbstractValidator<DeleteQueuePriorityRequest>
    {
        public DeleteQueuePriorityValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}