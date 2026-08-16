using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.Login;

public sealed record LoginRequest : IRequest<LoginResponse>
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}