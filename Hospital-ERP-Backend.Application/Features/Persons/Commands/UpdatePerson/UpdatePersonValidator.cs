using FluentValidation;
using Hospital_ERP_Backend.Domain.Enums;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.UpdatePerson
{
    internal class UpdatePersonValidator : AbstractValidator<UpdatePersonRequest>
    {
        public UpdatePersonValidator()
        {
            // Id
            RuleFor(x => x.Id)
                .GreaterThan(0);

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
                .WithMessage("Gender must be Male, Female, or Other");

            // Phone
            RuleFor(x => x.Phone)
                .NotEmpty()
                .Matches(@"^[0-9+\-]{8,20}$")
                .WithMessage("Phone must contain only numbers and optional + or -");

            // Address (optional)
            RuleFor(x => x.Address)
                .MaximumLength(250)
                .When(x => x.Address != null)
                .WithMessage("Address must not exceed 250 characters");
        }
    }
}
