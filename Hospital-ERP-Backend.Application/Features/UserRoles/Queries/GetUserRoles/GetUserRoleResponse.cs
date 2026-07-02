
namespace Hospital_ERP_Backend.Application.Features.UserRoles.Queries.GetUserRoles
{
    public record GetUserRoleResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
