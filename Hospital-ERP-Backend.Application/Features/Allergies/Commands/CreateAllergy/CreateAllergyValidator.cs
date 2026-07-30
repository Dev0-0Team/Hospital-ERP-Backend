using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.CreateAllergy
{
    public class CreateAllergyValidator : AbstractValidator<CreateAllergyRequest>
    {
        public CreateAllergyValidator()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0)
                .WithMessage("Patient Id must be greater than 0.");

            RuleFor(x => x.AllergyName)
                .NotEmpty().WithMessage("Please this field must be NOT empty")
                .MaximumLength(100);

            RuleFor(x => x.Severity)
                .IsInEnum()
                .WithMessage("Invalid Severity.");
        }
    }
}