using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetAllPrescriptions
{
    public class GetAllPrescriptionsValidator : AbstractValidator<GetAllPrescriptionsRequest>
    {
        public GetAllPrescriptionsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero.");
        }
    }
}