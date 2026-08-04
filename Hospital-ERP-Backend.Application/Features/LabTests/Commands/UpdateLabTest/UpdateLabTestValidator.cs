using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.UpdateLabTest
{
    internal class UpdateLabTestValidator : AbstractValidator<UpdateLabTestRequest>
    {
        public UpdateLabTestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be a positive integer.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(150).WithMessage("Name must not exceed 150 characters.");

            RuleFor(x => x.NormalRange)
                .NotEmpty().WithMessage("Normal range is required.")
                .MaximumLength(100).WithMessage("Normal range must not exceed 100 characters.");
        }
    }
}