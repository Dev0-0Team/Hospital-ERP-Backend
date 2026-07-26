using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Users.Queries.GetUser
{
    internal class GetUserValidator : AbstractValidator<GetUserRequest>
    {
        public GetUserValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
