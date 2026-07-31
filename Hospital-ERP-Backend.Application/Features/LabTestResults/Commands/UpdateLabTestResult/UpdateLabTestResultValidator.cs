using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.UpdateLabTestResult
{
    internal class UpdateLabTestResultValidator
        : AbstractValidator<UpdateLabTestResultRequest>
    {
        public UpdateLabTestResultValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0");

            RuleFor(x => x.LabOrderId)
                .GreaterThan(0).WithMessage("Lab Order ID must be greater than 0");

            RuleFor(x => x.LabTestId)
                .GreaterThan(0).WithMessage("Lab Test ID must be greater than 0");

            RuleFor(x => x.Result)
                .NotEmpty().WithMessage("Result cannot be empty")
                .MaximumLength(500).WithMessage("Result must not exceed 500 characters");
        }
    }
}