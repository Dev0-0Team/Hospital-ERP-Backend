
using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Persons.Queries.GetAllPersons
{
    internal class GetAllPersonsValidator : AbstractValidator<GetAllPersonsRequest>
    {
        public GetAllPersonsValidator()
        {
            RuleFor(x => x.page).GreaterThan(0)
                .WithMessage("Page number must be greater than 0.");
        }
    }
}
