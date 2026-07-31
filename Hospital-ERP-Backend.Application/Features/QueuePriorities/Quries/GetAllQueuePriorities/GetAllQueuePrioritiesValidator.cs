using FluentValidation;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetAllQueuePriorities;

namespace Hospital_ERP_Backend.Application.Features.QueuePriorities.Queries.GetAllQueuePriorities
{
 
    internal class GetAllQueuePrioritiesValidator : AbstractValidator<GetAllQueuePrioritiesRequest>
    {
        public GetAllQueuePrioritiesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}