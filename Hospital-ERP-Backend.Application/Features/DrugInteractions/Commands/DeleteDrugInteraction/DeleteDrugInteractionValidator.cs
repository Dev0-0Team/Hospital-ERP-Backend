using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.DeleteDrugInteraction
{
    internal class DeleteDrugInteractionValidator : AbstractValidator<DeleteDrugInteractionRequest>
    {
        public DeleteDrugInteractionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Drug Interaction Id must be greater than 0.");
        }
    }
}