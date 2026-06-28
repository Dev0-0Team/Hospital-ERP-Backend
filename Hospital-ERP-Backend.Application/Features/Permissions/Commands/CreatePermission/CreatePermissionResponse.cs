

namespace Hospital_ERP_Backend.Application.Features.Permissions.Commands.CreatePermission
{
    public record CreatePermissionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
