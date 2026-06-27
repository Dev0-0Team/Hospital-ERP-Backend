
using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Persons.Queries.GetPerson
{
    public class GetPersonValidator : AbstractValidator<GetPersonRequest>
    {
        public GetPersonValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
