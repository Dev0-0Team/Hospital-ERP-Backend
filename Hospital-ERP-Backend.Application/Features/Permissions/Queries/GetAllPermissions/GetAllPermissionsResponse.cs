
namespace Hospital_ERP_Backend.Application.Features.Permissions.Queries.GetAllPermissions
{
    public record GetAllPermissionsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
