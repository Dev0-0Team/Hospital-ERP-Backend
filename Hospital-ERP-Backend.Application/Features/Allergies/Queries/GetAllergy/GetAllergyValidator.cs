using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllergy
{
    public class GetAllergyValidator : AbstractValidator<GetAllergyRequest>
    {
        public GetAllergyValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}