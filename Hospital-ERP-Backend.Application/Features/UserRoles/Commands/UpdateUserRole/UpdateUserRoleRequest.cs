

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.UpdateUserRole
{
    public record UpdateUserRoleRequest : IRequest<UpdateUserRoleResponse>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
