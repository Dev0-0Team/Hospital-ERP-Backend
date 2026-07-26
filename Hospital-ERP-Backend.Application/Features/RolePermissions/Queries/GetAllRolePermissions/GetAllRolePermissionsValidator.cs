using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetAllRolePermissions
{
    internal class GetAllRolePermissionsValidator : AbstractValidator<GetAllRolePermissionsRequest>
    {
        public GetAllRolePermissionsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}
