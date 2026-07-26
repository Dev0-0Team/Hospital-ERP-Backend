using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetRolePermissions
{
    internal class GetRolePermissionsValidator : AbstractValidator<GetRolePermissionRequest>
    {
        public GetRolePermissionsValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
