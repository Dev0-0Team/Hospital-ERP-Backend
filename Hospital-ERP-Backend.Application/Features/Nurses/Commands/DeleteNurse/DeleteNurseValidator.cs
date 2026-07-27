using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.DeleteNurse
{
    internal class DeleteNurseValidator : AbstractValidator<DeleteNurseRequest>
    {
        public DeleteNurseValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
