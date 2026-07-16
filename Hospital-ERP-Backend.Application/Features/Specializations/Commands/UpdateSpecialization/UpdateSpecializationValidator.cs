using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Commands.UpdateSpecialization
{
    public class UpdateSpecializationValidator : AbstractValidator<UpdateSpecializationRequest>
    {
        public UpdateSpecializationValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is Required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        }
    }
}
