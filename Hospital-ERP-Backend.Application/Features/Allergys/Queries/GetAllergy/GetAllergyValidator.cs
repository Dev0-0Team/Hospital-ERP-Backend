using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Queries.GetAllergy
{
    public class GetAllergyValidator : AbstractValidator<GetAllergyRequest>
    {
        public GetAllergyValidator()
        {

            RuleFor(x => x.Id)
                .NotEmpty()

                .WithMessage("Patient ID is seruired");

        }
    }
}
