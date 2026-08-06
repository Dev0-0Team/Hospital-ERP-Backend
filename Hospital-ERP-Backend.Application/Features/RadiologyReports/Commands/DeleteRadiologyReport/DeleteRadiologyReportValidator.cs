using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyReports.Commands.DeleteRadiologyReport
{
    internal class DeleteRadiologyReportValidator : AbstractValidator<DeleteRadiologyReportRequest>
    {
        public DeleteRadiologyReportValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}