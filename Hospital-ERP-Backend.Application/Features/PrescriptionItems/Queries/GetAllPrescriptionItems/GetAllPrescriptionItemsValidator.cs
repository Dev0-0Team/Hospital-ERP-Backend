using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetAllPrescriptionItems
{
    internal class GetAllPrescriptionItemsValidator : AbstractValidator<GetAllPrescriptionItemsRequest>
    {
        public GetAllPrescriptionItemsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than 0.");
        }
    }
}