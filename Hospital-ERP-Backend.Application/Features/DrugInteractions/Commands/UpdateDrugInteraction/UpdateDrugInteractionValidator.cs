using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.UpdateDrugInteraction
{
    internal class UpdateDrugInteractionValidator : AbstractValidator<UpdateDrugInteractionRequest>
    {
        public UpdateDrugInteractionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be a greater than 0.");

            RuleFor(x => x.Medication1Id)
                .GreaterThan(0).WithMessage("Medication1Id must be a greater than 0.");

            RuleFor(x => x.Medication2Id)
                .GreaterThan(0).WithMessage("Medication2Id must be a greater than 0.");

            RuleFor(x => x.Severity)
                .NotEmpty().WithMessage("Severity is required.")
                .MaximumLength(50).WithMessage("Severity must not exceed 50 characters.");

            RuleFor(x => x.Warning)
                .NotEmpty().WithMessage("Warning is required.")
                .MaximumLength(500).WithMessage("Warning must not exceed 500 characters.");
        }
    }
}