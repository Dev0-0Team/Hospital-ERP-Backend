using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.UpdateLabTest
{
    public class UpdateLabTestValidator : AbstractValidator<UpdateLabTestRequest>
    {
        public UpdateLabTestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be a positive integer.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name must not exceed 255 characters.");

            RuleFor(x => x.NormalRange)
                .NotEmpty().WithMessage("Normal range is required.")
                .MaximumLength(255).WithMessage("Normal range must not exceed 255 characters.");
        }
    }
}