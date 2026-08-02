using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.CreateAllergy
{
    internal class CreateAllergyValidator : AbstractValidator<CreateAllergyRequest>
    {
        public CreateAllergyValidator()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0)
                .WithMessage("Patient Id must be greater than 0.");

            RuleFor(x => x.AllergyName)
                .NotEmpty().WithMessage("Please this field must be NOT empty")
                .MaximumLength(150).WithMessage("Allergy Name must not exceed 150 characters.");

            RuleFor(x => x.Severity)
                .IsInEnum()
                .WithMessage("Invalid Severity.");
        }
    }
}