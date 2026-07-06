using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.UpdateMedication
{
    public class UpdateMedicationValidator : AbstractValidator<UpdateMedicationRequest>
    {
        public UpdateMedicationValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be a positive number.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Medication name is required.")
                .MaximumLength(100).WithMessage("Medication name cannot exceed 100 characters.");

            RuleFor(x => x.DosageForm)
                .NotEmpty().WithMessage("Dosage form is required.")
                .MaximumLength(50).WithMessage("Dosage form cannot exceed 50 characters.");

            RuleFor(x => x.Manufacturer)
                .MaximumLength(150).WithMessage("Manufacturer cannot exceed 150 characters.");
        }
    }
}