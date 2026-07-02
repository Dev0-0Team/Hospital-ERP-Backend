
namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.CreateUserRole
{
    public record CreateUserRoleResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
