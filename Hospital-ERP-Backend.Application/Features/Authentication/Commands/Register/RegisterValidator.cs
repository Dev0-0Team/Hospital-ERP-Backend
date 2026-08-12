using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.Register;

public sealed class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MinimumLength(6).WithMessage("Full name must be at least 6 characters long.")
            .MaximumLength(200).WithMessage("Full name must not exceed 200 characters.")
            .Must(BeValidFullName).WithMessage("You must enter a full name with at least three parts (First, Middle, Last).");


        RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.")
                .MaximumLength(255).WithMessage("Email must not exceed 255 characters.")
                .Must(email => !email.Contains(" ")).WithMessage("Email must not contain spaces.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(100).WithMessage("Password must not exceed 100 characters.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .MaximumLength(20).WithMessage("Phone number must not exceed 20 characters.")
            .Matches(@"^\+?[0-9]{8,15}$")
            .WithMessage("Phone number must be a valid international number (digits only, optional + at the start).");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Gender is required.")
            .Must(g => g == "Male" || g == "Female" || g == "male" || g == "female")
            .WithMessage("Gender must be either Male or Female.");
        RuleFor(x => x.Dob)
            .NotEmpty().WithMessage("Date of birth is required.")
            .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.")
            .GreaterThan(DateTime.Today.AddYears(-120)).WithMessage("Date of birth is not valid.")
            .Must(BeAtLeast18YearsOld).WithMessage("User must be at least 18 years old.");
    }
    private bool BeValidFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return false;

        var parts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return parts.Length >= 3;
    }

    private bool BeAtLeast18YearsOld(DateTime dob)
    {
        var age = DateTime.Today.Year - dob.Year;
        if (dob.Date > DateTime.Today.AddYears(-age)) age--;
        return age >= 18;
    }
}