using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;


namespace Hospital_ERP_Backend.Application.Features.Users.Commands.DeleteUser
{
    internal class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0)
              .WithMessage("Id must be greater than 0.");
        }
    }
}
