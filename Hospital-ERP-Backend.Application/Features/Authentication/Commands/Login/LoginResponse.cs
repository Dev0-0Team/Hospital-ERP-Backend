namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.Login;

public sealed record LoginResponse
{
    public string Token { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime ExpireAt { get; set; }

    public int UserId { get; set; }

    public int PersonId { get; set; }
}