

using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetAllPermissionsOfUser
{
    internal class GetAllPermissionsOfUserValidator : AbstractValidator<GetAllPermissionsOfUserRequest>
    {
        public GetAllPermissionsOfUserValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("User Id number must be greater than 0.");
        }
    }
}