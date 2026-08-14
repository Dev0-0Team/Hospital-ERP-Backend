using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.CreateEmergencyCases
{
    public class CreateEmergencyCasesValidator : AbstractValidator<CreateEmergencyCasesRequest>
    {
        public CreateEmergencyCasesValidator()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Patient id must be greater than zero");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(20).WithMessage("Status must not exceed 20 characters.");

            RuleFor(x => x.TriageColor)
                .NotEmpty().WithMessage("Triage color is required.")
                .MaximumLength(10).WithMessage("Triage color must not exceed 10 characters.");

            RuleFor(x => x.ArrivalTime)
                .NotEmpty().WithMessage("Arrival time is required.");
        }
    }
}