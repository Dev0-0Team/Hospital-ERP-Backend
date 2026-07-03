
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.DeleteUserRole
{
    public record DeleteUserRoleRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
