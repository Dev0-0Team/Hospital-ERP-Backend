

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Permission : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Group { get; set; } = null!;

    public ulong BitValue { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public ICollection<Role> Roles { get; set; } = new List<Role>();
}
