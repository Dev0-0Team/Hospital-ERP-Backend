using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;

namespace Hospital_ERP_Backend.Application.Features.Users.Commands.CreateUser
{
    internal class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.PersonId).GreaterThan(0)
                .WithMessage("Person Id must be greater than 0.");
            
            RuleFor(x => x.Email)
                .MaximumLength(255)
                .When(x => x.Email != null)
                .WithMessage("Email must be at most 255 characters long");

            RuleFor(x => x.Password)
                .MaximumLength(char.MaxValue)
                .When(x => x.Password != null)
                .WithMessage($"Password must be at most {char.MaxValue} characters long");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Invalid Person Gender");
        }
    }
}
