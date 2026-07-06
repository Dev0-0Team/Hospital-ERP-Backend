using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Medications.Commands.DeleteMedication
{
    public class DeleteMedicationValidator : AbstractValidator<DeleteMedicationRequest>
    {
        public DeleteMedicationValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Medication Id must be greater than 0.");
        }
    }
}
