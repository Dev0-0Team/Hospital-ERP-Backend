using FluentValidation;
using Hospital_ERP_Backend.Domain.Enums;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.CreatePerson
{
    internal class CreatePersonValidator : AbstractValidator<CreatePersonRequest>
    {
        public CreatePersonValidator() 
        {
            // Full Name
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(255)
                .WithMessage("Full name must not exceed 255 characters");

            // Date of Birth
            RuleFor(x => x.Dob)
                .LessThan(DateTime.Today)
                .WithMessage("Date of birth must be in the past");

            // Gender
            RuleFor(x => x.Gender)
                .NotEmpty()
                .Must(x => Enum.IsDefined(typeof(PersonGender), x))
                .WithMessage("Invalid Person Gender");

            // Phone
            RuleFor(x => x.Phone)
                .NotEmpty()
                .Matches(@"^[0-9+\-]{8,20}$")
                .WithMessage("Phone must contain only numbers and optional + or -");

            // Address (optional)
            RuleFor(x => x.Address)
                .MaximumLength(250)
                .When(x => x.Address != null)
                .WithMessage("Address must be at most 250 characters long");
        }
    }
}
