using FluentValidation;
namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Queries.GetAllEmergencyContacts
{
    public class GetAllEmergencyContactsValidator : AbstractValidator<GetAllEmergencyContactsRequest>
    {
        public GetAllEmergencyContactsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero");
        }
    }
}