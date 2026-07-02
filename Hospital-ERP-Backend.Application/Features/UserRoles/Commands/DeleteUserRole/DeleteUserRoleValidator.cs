using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.DeleteUserRole
{
    public class DeleteUserRoleValidator : AbstractValidator<DeleteUserRoleRequest>
    {
        public DeleteUserRoleValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("UserRole Id must be greater than 0.");
        }
    }
}
