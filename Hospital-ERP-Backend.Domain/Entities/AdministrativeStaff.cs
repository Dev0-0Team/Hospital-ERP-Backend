
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class AdministrativeStaff : BaseEntity
{
    public int PersonId { get; set; }

    public int DepartmentId { get; set; }

    public string JobTitle { get; set; } = null!;

    public Department Department { get; set; } = null!;

    public Person Person { get; set; } = null!;
}
