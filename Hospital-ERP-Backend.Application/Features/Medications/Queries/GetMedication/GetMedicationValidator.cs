using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Medications.Queries.GetMedicationById
{
    internal class GetMedicationValidator : AbstractValidator<GetMedicationRequest>
    {
        public GetMedicationValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Medication ID must be greater than 0.");
        }
    }
}
