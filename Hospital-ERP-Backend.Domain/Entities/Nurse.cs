

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Nurse : BaseEntity
{
    public int PersonId { get; set; }

    public int DepartmentId { get; set; }

    public Department Department { get; set; } = null!;

    public Person Person { get; set; } = null!;
}
