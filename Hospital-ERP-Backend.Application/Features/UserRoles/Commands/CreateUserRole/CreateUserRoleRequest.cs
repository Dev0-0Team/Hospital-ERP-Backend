
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.CreateUserRole
{
    public record CreateUserRoleRequest : IRequest<CreateUserRoleResponse>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
