using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.UpdatePrescriptionItem
{
    public class UpdatePrescriptionItemValidator : AbstractValidator<UpdatePrescriptionItemRequest>
    {
        public UpdatePrescriptionItemValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be a greater than 0.");

            RuleFor(x => x.PrescriptionId)
                .GreaterThan(0).WithMessage("PrescriptionId must be a greater than 0.");

            RuleFor(x => x.MedicationId)
                .GreaterThan(0).WithMessage("MedicationId must be a greater than 0.");

            RuleFor(x => x.Dosage)
                .NotEmpty().WithMessage("Dosage is required.");

            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("Duration is required.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be a greater than 0.");

            RuleFor(x => x.Instructions)
                .MaximumLength(500).WithMessage("Instructions must be at most 500 characters long.");
        }
    }
}