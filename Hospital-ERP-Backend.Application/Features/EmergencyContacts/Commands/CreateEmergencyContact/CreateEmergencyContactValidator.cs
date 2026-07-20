using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.CreateEmergencyContact
{
    public class CreateEmergencyContactValidator : AbstractValidator<CreateEmergencyContactRequest>
    {
        public CreateEmergencyContactValidator()
        {
            // Patient Id
            RuleFor(x => x.PatientId)
                .GreaterThan(0)
                .WithMessage("Patient id must be greater than zero");

            // Name
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(255)
                .WithMessage("Name must not exceed 255 characters");

            // Phone
            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone is required")
                .Matches(@"^[0-9+\-]{8,20}$")
                .WithMessage("Phone must contain only numbers and optional + or -");

            // Relationship
            RuleFor(x => x.Relationship)
                .NotEmpty()
                .WithMessage("Relationship is required")
                .MaximumLength(50)
                .WithMessage("Relationship must not exceed 50 characters");
        }
    }
}