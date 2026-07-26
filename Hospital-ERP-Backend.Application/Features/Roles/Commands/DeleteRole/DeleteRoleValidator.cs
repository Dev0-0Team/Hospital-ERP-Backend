using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Roles.Commands.DeleteRole
{
    internal class DeleteRoleValidator : AbstractValidator<DeleteRoleRequest>
    {
        public DeleteRoleValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
