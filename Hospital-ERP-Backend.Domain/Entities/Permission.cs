

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Permission
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Role> Roles { get; set; } = new List<Role>();
}
