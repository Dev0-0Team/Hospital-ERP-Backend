
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.UpdateRolePermission
{
    public record UpdateRolePermissionRequest : IRequest<UpdateRolePermissionResponse>
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
