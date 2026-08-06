using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetLabTestResult
{
    internal class GetLabTestResultValidator : AbstractValidator<GetLabTestResultRequest>
    {
        public GetLabTestResultValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Lab Test Result Id must be greater than 0.");
        }
    }
}