using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.DeleteLabTest
{
    internal class DeleteLabTestValidator : AbstractValidator<DeleteLabTestRequest>
    {
        public DeleteLabTestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Lab test ID must be a positive number.");
        }
    }
}