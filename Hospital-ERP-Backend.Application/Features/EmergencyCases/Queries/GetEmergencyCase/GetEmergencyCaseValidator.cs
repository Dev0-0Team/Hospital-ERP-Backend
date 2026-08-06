using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Queries.GetEmergencyCase
{
    public class GetEmergencyCaseValidator : AbstractValidator<GetEmergencyCaseRequest>
    {
        public GetEmergencyCaseValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than zero");
        }
    }
}
