
using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.CreateUserRole
{
    internal class CreateUserRoleValidator : AbstractValidator<CreateUserRoleRequest>
    {
        public CreateUserRoleValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than 0.");
        }
    }
}
