using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.UpdateEmergencyContact
{
    internal class UpdateEmergencyContactValidator : AbstractValidator<UpdateEmergencyContactRequest>
    {
        public UpdateEmergencyContactValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be a positive integer.");

            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Patient id must be a positive integer.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name must not exceed 255 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^[0-9+\-]{8,20}$").WithMessage("Phone must contain only numbers and optional + or -");

            RuleFor(x => x.Relationship)
                .NotEmpty().WithMessage("Relationship is required.")
                .MaximumLength(50).WithMessage("Relationship must not exceed 50 characters.");
        }
    }
}