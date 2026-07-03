using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetRolePermissions
{
    public class GetRolePermissionsValidator : AbstractValidator<GetRolePermissionsRequest>
    {
        public GetRolePermissionsValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
