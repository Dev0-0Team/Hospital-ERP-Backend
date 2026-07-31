using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetLabOrder
{
    internal class GetLabOrderValidator : AbstractValidator<GetLabOrderRequest>
    {
        public GetLabOrderValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Lab Order Id must be greater than 0.");
        }
    }
}