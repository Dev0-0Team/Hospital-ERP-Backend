using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.Logout;

public sealed class LogoutValidator : AbstractValidator<LogoutRequest>
{
    public LogoutValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty();
    }
}