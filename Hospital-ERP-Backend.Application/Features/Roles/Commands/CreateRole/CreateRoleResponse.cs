

namespace Hospital_ERP_Backend.Application.Features.Roles.Commands.CreateRole
{
    public record CreateRoleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
