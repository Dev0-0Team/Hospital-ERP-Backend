using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetRadiologyOrder
{
    internal class GetRadiologyOrderValidator
        : AbstractValidator<GetRadiologyOrderRequest>
    {
        public GetRadiologyOrderValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Radiology Order Id must be greater than 0.");
        }
    }
}