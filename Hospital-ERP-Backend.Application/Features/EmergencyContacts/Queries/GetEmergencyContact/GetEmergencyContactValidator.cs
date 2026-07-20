using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Queries.GetEmergencyContact
{
    public class GetEmergencyContactValidator : AbstractValidator<GetEmergencyContactRequest>
    {

        public GetEmergencyContactValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than zero");

        }
    }
}