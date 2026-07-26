using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.Permissions.Commands.DeletePermission
{
    internal class DeletePermissionValidator : AbstractValidator<DeletePermissionRequest>
    {
        public DeletePermissionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Permission Id must be greater than zero.");
        }
    }
}
