
using FluentValidation;

namespace Hospital_ERP_Backend.Application.Persons.Queries.GetPerson
{
    public class GetPersonValidator : AbstractValidator<GetPersonRequest>
    {
        public GetPersonValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
