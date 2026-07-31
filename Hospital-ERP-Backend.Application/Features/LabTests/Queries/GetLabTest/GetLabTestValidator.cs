using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Queries.GetLabTest
{
    internal class GetLabTestValidator : AbstractValidator<GetLabTestRequest>
    {
        public GetLabTestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than zero");
        }
    }
}
