using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.CreateDrugInteraction
{
    public class CreateDrugInteractionValidator : AbstractValidator<CreateDrugInteractionRequest>
    {
        public CreateDrugInteractionValidator()
        {
            RuleFor(x => x.Medication1Id)
                .GreaterThan(0).WithMessage("Medication 1 ID must be greater than 0");

            RuleFor(x => x.Medication2Id)
                .GreaterThan(0).WithMessage("Medication 2 ID must be greater than 0");

            RuleFor(x => x.Severity)
                .NotEmpty().WithMessage("Severity is required.")
                .MaximumLength(50).WithMessage("Severity must not exceed 50 characters.");

            RuleFor(x => x.Warning)
                .NotEmpty().WithMessage("Warning is required.")
                .MaximumLength(500).WithMessage("Warning must not exceed 500 characters.");
        }
    }
}