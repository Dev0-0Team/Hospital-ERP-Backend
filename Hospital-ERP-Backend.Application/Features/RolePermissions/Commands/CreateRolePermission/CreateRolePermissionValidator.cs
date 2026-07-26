
using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.CreateRolePermission
{
    internal class CreateRolePermissionValidator : AbstractValidator<CreateRolePermissionRequest>
    {
        public CreateRolePermissionValidator()
        {
            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than 0.");
            RuleFor(x => x.PermissionId)
                .GreaterThan(0).WithMessage("PermissionId must be greater than 0.");
        }
    }
}
