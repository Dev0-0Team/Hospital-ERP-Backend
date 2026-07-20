using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.DeleteEmergencyContact
{
    public class DeleteEmergencyContactValidator : AbstractValidator<DeleteEmergencyContactRequest>
    {
        public DeleteEmergencyContactValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Emergency contact ID must be a positive number.");
        }
    }
}