using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.RefreshTokens;

public sealed class RefreshTokenValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("Refresh Token is required.");
    }
}