using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Queries.GetAllLabTestResults
{
    internal class GetAllLabTestResultsValidator : AbstractValidator<GetAllLabTestResultsRequest>
    {
        public GetAllLabTestResultsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero.");
        }
    }
}