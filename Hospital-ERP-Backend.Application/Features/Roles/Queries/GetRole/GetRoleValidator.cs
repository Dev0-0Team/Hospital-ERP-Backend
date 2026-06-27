using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Roles.Queries.GetRole
{
    public class GetRoleValidator : AbstractValidator<GetRoleRequest>
    {
        public GetRoleValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Role Id must be greater than 0.");
        }
    }
}
