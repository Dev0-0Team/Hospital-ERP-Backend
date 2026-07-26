using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Users.Commands.UpdateUser
{
    internal class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0)
                .WithMessage("Id must be greater than 0.");

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
                .NotEmpty()
                .Must(BeValidStatus)
                .WithMessage("Status must be Active or InActive");
        }
        private bool BeValidStatus(string Status)
        {
            var allowed = new[] { "Active", "InActive" };
            return allowed.Contains(Status);
        }
    }
}
