using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.Specializations.Commands.CreateSpecialization
{
    internal class CreateSpecializationValidator : AbstractValidator<CreateSpecializationRequest>
    {
        public CreateSpecializationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        }
    }
}
