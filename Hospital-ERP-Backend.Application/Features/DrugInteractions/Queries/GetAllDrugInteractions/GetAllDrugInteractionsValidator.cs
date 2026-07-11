using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetAllDrugInteractions
{
    public class GetAllDrugInteractionsValidator : AbstractValidator<GetAllDrugInteractionsRequest>
    {
        public GetAllDrugInteractionsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero.");
        }
    }
}