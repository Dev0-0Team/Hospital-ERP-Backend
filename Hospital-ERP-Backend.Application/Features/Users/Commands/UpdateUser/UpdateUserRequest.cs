
using Hospital_ERP_Backend.Domain.Enums;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserStatus Status { get; set; } = UserStatus.Active;
    }
}
