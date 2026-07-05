
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.CreateRolePermission
{
    public record CreateRolePermissionRequest : IRequest<CreateRolePermissionResponse>
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
