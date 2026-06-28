using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetPermission
{
    public class GetPermissionValidator : AbstractValidator<GetPermissionRequest>
    {
        public GetPermissionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Permission Id must be greater than 0.");
        }
    }
}
