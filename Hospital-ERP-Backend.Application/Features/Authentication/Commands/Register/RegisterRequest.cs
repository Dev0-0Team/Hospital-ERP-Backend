using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Authentication.Commands.Register;

public sealed record RegisterRequest : IRequest<RegisterResponse>
{
    public string FullName { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Gender { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}