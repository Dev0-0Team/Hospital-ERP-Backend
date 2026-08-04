using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.CreateMedication
{
    internal class CreateMedicationValidator : AbstractValidator<CreateMedicationRequest>
    {
        public CreateMedicationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Medication name is required.")
                .MaximumLength(255).WithMessage("Medication name cannot exceed 255 characters.");

            RuleFor(x => x.DosageForm)
                .NotEmpty().WithMessage("Dosage form is required.")
                .MaximumLength(50).WithMessage("Dosage form cannot exceed 50 characters.");

            RuleFor(x => x.Manufacturer)
                .MaximumLength(150).WithMessage("Manufacturer cannot exceed 150 characters.");
        }
    }
}