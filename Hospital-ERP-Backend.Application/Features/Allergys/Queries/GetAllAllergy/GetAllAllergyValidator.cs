using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Queries.GetAllAllergy
{
    public class GetAllAllergyValidator : AbstractValidator<GetAllAllergyRequest>
    {
        public GetAllAllergyValidator()
        {

            RuleFor(x => x.AllergyName)
                .NotEmpty()
                .WithMessage("Allergy name is required");

            RuleFor(x => x.Severity)
                .NotEmpty()
                .MaximumLength(255)
                .WithMessage("Allergy name must not exceed 255 characters");

              


            RuleFor(x => x.Id)
                .NotEmpty()

                .WithMessage("Patient ID is seruired");

        }
    }
}
