using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetAllLabOrders
{
    public class GetAllLabOrdersValidator : AbstractValidator<GetAllLabOrdersRequest>
    {
        public GetAllLabOrdersValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be a positive number.");
        }
    }
}