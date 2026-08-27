using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.RefreshTokens;

public sealed record RefreshTokenRequest : IRequest<RefreshTokenResponse>
{
    public string RefreshToken { get; set; } = null!;
}