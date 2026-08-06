using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Queries.GetRadiologyReport
{
    internal class GetRadiologyReportValidator
        : AbstractValidator<GetRadiologyReportRequest>
    {
        public GetRadiologyReportValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Radiology Report Id must be greater than 0.");
        }
    }
}