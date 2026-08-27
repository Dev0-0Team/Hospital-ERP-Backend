using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.Logout;

public sealed record LogoutRequest : IRequest<bool>
{
    public int UserId { get; set; }
    public string RefreshToken { get; set; } = null!;
}