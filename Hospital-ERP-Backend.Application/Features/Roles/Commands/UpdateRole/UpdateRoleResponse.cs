

namespace Hospital_ERP_Backend.Application.Features.Roles.Commands.UpdateRole
{
    public record UpdateRoleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
