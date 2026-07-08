using FluentValidation;
namespace Hospital_ERP_Backend.Application.Features.LapTests.Queries.GetAllLabTests
{
    public class GetAllLabTestsValidator : AbstractValidator<GetAllLabTestsRequest>
    {
        public GetAllLabTestsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero");
        }
    }
}
