

namespace Hospital_ERP_Backend.Application.Features.UserRoles.Commands.UpdateUserRole
{
    public record UpdateUserRoleResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
