using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonValidator : AbstractValidator<DeletePersonRequest>
    {
        public DeletePersonValidator() 
        {
            RuleFor(x => x.Id).GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
