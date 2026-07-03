

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetAllRolePermissions
{
    public record GetAllRolePermissionsResponse
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
