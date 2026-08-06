using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.UpdateAllergy
{
    internal class UpdateAllergyValidator : AbstractValidator<UpdateAllergyRequest>
    {
        public UpdateAllergyValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Allergy Id must be greater than 0.");

            RuleFor(x => x.PatientId)
                .GreaterThan(0)
                .WithMessage("Patient Id must be greater than 0.");

            RuleFor(x => x.AllergyName)
                .NotEmpty()
                .MaximumLength(150).WithMessage("Allergy Name must not exceed 150 characters.");

            RuleFor(x => x.Severity)
                .IsInEnum()
                .WithMessage("Invalid Severity.");
        }
    }
}