using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.UpdateRadiologyReport
{
    internal class UpdateRadiologyReportValidator : AbstractValidator<UpdateRadiologyReportRequest>
    {
        public UpdateRadiologyReportValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");

            RuleFor(x => x.RadiologyOrderId)
                  .GreaterThan(0).WithMessage("Radiology order id must be greater than 0.");

            RuleFor(x => x.Report)
                .NotEmpty()
                .MaximumLength(4000).WithMessage("Report must not exceed 4000 characters");
        }
    }
}