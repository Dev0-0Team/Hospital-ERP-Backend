
namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.CreateUserRole
{
    public record CreateUserRoleRequest
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
