
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.DeleteRolePermission
{
    public record DeleteRolePermissionRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
