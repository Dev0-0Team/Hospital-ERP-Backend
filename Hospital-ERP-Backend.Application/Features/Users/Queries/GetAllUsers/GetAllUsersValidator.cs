

using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersValidator : AbstractValidator<GetAllUsersRequest>
    {
        public GetAllUsersValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}
