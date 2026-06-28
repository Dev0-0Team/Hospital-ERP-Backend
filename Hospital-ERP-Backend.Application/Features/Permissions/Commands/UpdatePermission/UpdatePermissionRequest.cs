

namespace Hospital_ERP_Backend.Application.Features.Permissions.Commands.UpdatePermission
{
    public record UpdatePermissionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
