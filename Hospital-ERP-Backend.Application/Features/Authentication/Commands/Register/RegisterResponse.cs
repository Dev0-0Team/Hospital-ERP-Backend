namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.Register;

public sealed record RegisterResponse
{
    public int UserId { get; set; }

    public int PersonId { get; set; }

    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;
}