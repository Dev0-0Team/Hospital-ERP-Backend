

using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.UpdateRolePermission
{
    internal class UpdateRolePermissionValidator : AbstractValidator<UpdateRolePermissionRequest>
    {
        public UpdateRolePermissionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than 0.");
            RuleFor(x => x.PermissionId)
                .GreaterThan(0).WithMessage("PermissionId must be greater than 0.");
        }
    }
}
