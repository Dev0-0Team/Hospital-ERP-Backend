using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesValidator : AbstractValidator<GetAllRolesRequest>
    {
        public GetAllRolesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}
