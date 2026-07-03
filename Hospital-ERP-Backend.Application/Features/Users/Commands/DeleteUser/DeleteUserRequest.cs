

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Users.Commands.DeleteUser
{
    public record DeleteUserRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
