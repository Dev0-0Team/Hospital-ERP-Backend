namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.RefreshTokens;

public sealed record RefreshTokenResponse
{
    public string AccessToken { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;

    public DateTime ExpireAt { get; set; }
}