using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetAllPermissions
{
    public class GetAllPermissionsValidator : AbstractValidator<GetAllPermissionsRequest>
    {
        public GetAllPermissionsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}
