using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllAllergies
{
    public class GetAllAllergiesValidator :
        AbstractValidator<GetAllAllergiesRequest>
    {
        public GetAllAllergiesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than 0.");
        }
    }
}