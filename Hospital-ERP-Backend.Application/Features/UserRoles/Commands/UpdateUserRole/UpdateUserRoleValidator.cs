using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.UpdateUserRole
{
    internal class UpdateUserRoleValidator : AbstractValidator<UpdateUserRoleRequest>
    {
        public UpdateUserRoleValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("UserRole Id must be greater than 0.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than 0.");
        }
    }
}
