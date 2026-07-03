

namespace Hospital_ERP_Backend.Application.Features.RolePermissions.Query.GetRolePermissions
{
    public record GetRolePermissionsResponse
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
