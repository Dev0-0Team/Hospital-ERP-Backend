using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Commands.DeleteSpecialization
{
    public class DeleteSpecializationValidator : AbstractValidator<DeleteSpecializationRequest>
    {
        public DeleteSpecializationValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
