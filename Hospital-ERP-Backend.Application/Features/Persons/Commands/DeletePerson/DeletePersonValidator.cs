using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonValidator : AbstractValidator<DeletePersonRequest>
    {
        public DeletePersonValidator() 
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
