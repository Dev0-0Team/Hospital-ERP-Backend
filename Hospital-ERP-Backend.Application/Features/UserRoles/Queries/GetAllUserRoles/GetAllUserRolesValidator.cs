

using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetAllUserRoles
{
    public class GetAllUserRolesValidator : AbstractValidator<GetAllUserRolesRequest>
    {
        public GetAllUserRolesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}
