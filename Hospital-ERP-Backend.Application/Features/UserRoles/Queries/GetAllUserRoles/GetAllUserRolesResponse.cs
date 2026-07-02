

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetAllUserRoles
{
    public record GetAllUserRolesResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
