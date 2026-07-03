
namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Command.CreateRolePermission
{
    public record CreateRolePermissionResponse
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
