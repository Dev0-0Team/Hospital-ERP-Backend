using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Commands.CreateLabTest
{
    public class CreateLabTestValidator : AbstractValidator<CreateLabTestRequest>
    {
        public CreateLabTestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(100)
                .WithMessage("Name must not exceed 100 characters");
            RuleFor(x => x.NormalRange)
                .NotEmpty()
                .WithMessage("Normal range is required")
                .MaximumLength(50)
                .WithMessage("Normal range must not exceed 50 characters");


        }
    }
}
