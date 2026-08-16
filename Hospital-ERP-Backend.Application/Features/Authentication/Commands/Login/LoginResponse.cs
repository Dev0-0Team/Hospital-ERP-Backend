namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.Login;

public sealed record LoginResponse
{
    public string Token { get; set; } = null!;

    public DateTime ExpireAt { get; set; }
}