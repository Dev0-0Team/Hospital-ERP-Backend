using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Queries.GetAllEmergencyCases
{
    public class GetAllEmergencyCasesValidator : AbstractValidator<GetAllEmergencyCasesRequest>
    {
        public GetAllEmergencyCasesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero");
        }
    }
}
