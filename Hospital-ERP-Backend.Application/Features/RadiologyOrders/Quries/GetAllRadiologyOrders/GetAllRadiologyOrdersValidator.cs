using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetAllRadiologyOrders
{
    internal class GetAllRadiologyOrdersValidator
        : AbstractValidator<GetAllRadiologyOrdersRequest>
    {
        public GetAllRadiologyOrdersValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero.");
        }
    }
}