using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesValidator : AbstractValidator<GetAllRolesRequest>
    {
        public GetAllRolesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page number must be a positive integer.");
        }
    }
}
