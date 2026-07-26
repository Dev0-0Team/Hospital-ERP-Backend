using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Commands.CreatePermission
{
    internal class CreatePermissionValidator : AbstractValidator<CreatePermissionRequest>
    {
        public CreatePermissionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Permission name is required.")
                .MaximumLength(100).WithMessage("Permission name must not exceed 100 characters.");
        }
    }
}
