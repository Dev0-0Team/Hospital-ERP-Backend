using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.CreateMedication
{
    internal class CreateMedicationValidator : AbstractValidator<CreateMedicationRequest>
    {
        public CreateMedicationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Medication name is required.")
                .MaximumLength(255);

            RuleFor(x => x.DosageForm)
                .NotEmpty().WithMessage("Dosage form is required.")
                .MaximumLength(50);

            RuleFor(x => x.Manufacturer)
                .MaximumLength(150).WithMessage("Manufacturer name is too long.");
        }
    }
}