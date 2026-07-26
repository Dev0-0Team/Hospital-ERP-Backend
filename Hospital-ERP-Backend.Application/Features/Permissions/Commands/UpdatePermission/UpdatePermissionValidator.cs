using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Commands.UpdatePermission
{
    internal class UpdatePermissionValidator : AbstractValidator<UpdatePermissionRequest>
    {
        public UpdatePermissionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Permission Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Permission Name is required.")
                .MaximumLength(100).WithMessage("Permission Name must not exceed 100 characters.");
        }
    }
}
