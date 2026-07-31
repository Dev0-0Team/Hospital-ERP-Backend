using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabTestResults.Commands.DeleteLabTestResult
{
    internal class DeleteLabTestResultValidator
        : AbstractValidator<DeleteLabTestResultRequest>
    {
        public DeleteLabTestResultValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}