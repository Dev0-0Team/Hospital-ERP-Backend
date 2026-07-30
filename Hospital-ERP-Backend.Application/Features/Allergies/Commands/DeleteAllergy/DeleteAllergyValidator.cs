using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.DeleteAllergy
{
    public class DeleteAllergyValidator : AbstractValidator<DeleteAllergyRequest>
    {
        public DeleteAllergyValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Allergy Id must be greater than 0.");
        }
    }
}