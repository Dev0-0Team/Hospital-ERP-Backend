using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetDrugInteraction
{
    public class GetDrugInteractionValidator : AbstractValidator<GetDrugInteractionRequest>
    {
        public GetDrugInteractionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Drug Interaction Id must be greater than 0.");
        }
    }
}