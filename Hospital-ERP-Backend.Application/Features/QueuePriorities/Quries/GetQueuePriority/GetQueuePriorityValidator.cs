using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetQueuePriority
{
  
    internal class GetQueuePriorityValidator : AbstractValidator<GetQueuePriorityRequest>
    {
        public GetQueuePriorityValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Queue priority Id must be greater than 0.");
        }
    }
}