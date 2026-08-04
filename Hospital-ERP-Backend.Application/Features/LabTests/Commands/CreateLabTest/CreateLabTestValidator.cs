using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.CreateLabTest
{
    internal class CreateLabTestValidator : AbstractValidator<CreateLabTestRequest>
    {
        public CreateLabTestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(150)
                .WithMessage("Name must not exceed 150 characters");
            RuleFor(x => x.NormalRange)
                .NotEmpty()
                .WithMessage("Normal range is required")
                .MaximumLength(100)
                .WithMessage("Normal range must not exceed 100 characters");


        }
    }
}
