using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetUserRoles
{
    public class GetUserRoleValidator : AbstractValidator<GetUserRoleRequest>
    {
        public GetUserRoleValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
