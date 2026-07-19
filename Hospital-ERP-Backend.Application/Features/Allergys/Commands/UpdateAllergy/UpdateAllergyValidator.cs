using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Commands.UpdateAllergy
{
    public class UpdateAllergyValidator : AbstractValidator<UpdateAllergyRequest>
    {
        public UpdateAllergyValidator()
        {

            RuleFor(x => x.AllergyName)
                .NotEmpty()
                .WithMessage("Allergy name is required")
                .MaximumLength(255)
                .WithMessage("Allergy name must not exceed 255 characters");


            RuleFor(x => x.Severity)
                .NotEmpty()
                .WithMessage("Severity Is required")
                .IsInEnum()
                .WithMessage("Severity Must be a Valid Value");


            RuleFor(x => x.Id)
                .NotEmpty()

                .WithMessage("Patient ID is seruired");

        }
    }
}
