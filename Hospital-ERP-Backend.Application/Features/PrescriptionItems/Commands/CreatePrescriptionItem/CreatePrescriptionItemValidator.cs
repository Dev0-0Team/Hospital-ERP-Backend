using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.CreatePrescriptionItem
{
    public class CreatePrescriptionItemValidator : AbstractValidator<CreatePrescriptionItemRequest>
    {
        public CreatePrescriptionItemValidator()
        {
            RuleFor(x => x.PrescriptionId)
                .GreaterThan(0).WithMessage("PrescriptionId must be greater than 0.");

            RuleFor(x => x.MedicationId)
                .GreaterThan(0).WithMessage("MedicationId must be greater than 0.");

            RuleFor(x => x.Dosage)
                .NotEmpty().WithMessage("Dosage is required.");

            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("Duration is required.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.Instructions)
                .MaximumLength(500).WithMessage("Instructions must not exceed 500 characters.");
        }
    }
}