using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetAllRadiologyReports
{
    public class GetAllRadiologyReportsValidator
        : AbstractValidator<GetAllRadiologyReportsRequest>
    {
        public GetAllRadiologyReportsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero.");
        }
    }
}