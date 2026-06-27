using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonRequest>
    {
        public CreatePersonValidator() 
        {
            // Full Name
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(255);

            // Date of Birth
            RuleFor(x => x.Dob)
                .LessThan(DateTime.Today)
                .WithMessage("Date of birth must be in the past");

            // Gender
            RuleFor(x => x.Gender)
                .NotEmpty()
                .Must(BeValidGender)
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
                .WithMessage("Address must be at most 250 characters long");
        }

        private bool BeValidGender(string gender)
        {
            var allowed = new[] { "Male", "Female", "Other" };
            return allowed.Contains(gender);
        }
    }
}
