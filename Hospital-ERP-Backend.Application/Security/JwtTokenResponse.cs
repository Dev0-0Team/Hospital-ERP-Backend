namespace Hospital_ERP_Backend.Application.Security;

public sealed class JwtTokenResponse
{
    public string Token { get; set; } = string.Empty;

    public DateTime ExpireAt { get; set; }
}