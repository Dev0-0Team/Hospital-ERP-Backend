
namespace Hospital_ERP_Backend.Domain.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int RoleId { get; set; }

        public User User { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
