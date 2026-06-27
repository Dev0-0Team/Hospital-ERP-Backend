using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.UpdatePerson
{
    public class UpdatePersonValidator : AbstractValidator<UpdatePersonRequest>
    {
        public UpdatePersonValidator()
        {
            // Id
            RuleFor(x => x.Id)
                .GreaterThan(0);

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
                .When(x => x.Address != null);
        }

        private bool BeValidGender(string gender)
        {
            var allowed = new[] { "Male", "Female", "Other" };
            return allowed.Contains(gender);
        }
    }
}
