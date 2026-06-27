

namespace Hospital_ERP_Backend.Application.Features.Roles.Queries.GetAllRoles
{
    public record GetAllRolesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
