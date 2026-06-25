
using FluentValidation;

namespace Hospital_ERP_Backend.Application.Persons.Queries.GetAllPersons
{
    public class GetAllPersonsValidator : AbstractValidator<GetAllPersonsRequest>
    {
        public GetAllPersonsValidator()
        {
            RuleFor(x => x.page).GreaterThanOrEqualTo(1);
        }
    }
}
