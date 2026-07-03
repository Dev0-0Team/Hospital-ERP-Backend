using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.DeleteRolePermission
{
    public class DeleteRolePermissionValidator : AbstractValidator<DeleteRolePermissionRequest>
    {
        public DeleteRolePermissionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

