namespace Hospital_ERP_Backend.Domain.Entities;

public partial class User : BaseEntity
{
    public int PersonId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Status { get; set; } = null!;

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public Person Person { get; set; } = null!;
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<Role> Roles { get; set; } = new List<Role>();
}
