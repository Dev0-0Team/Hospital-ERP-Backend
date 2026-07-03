namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Role : BaseEntity
{
    public string Name { get; set; } = null!;

    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public ICollection<User> Users { get; set; } = new List<User>();
}
