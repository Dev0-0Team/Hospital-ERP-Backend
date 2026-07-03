namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Specialization : BaseEntity
{

    public string Name { get; set; } = null!;

    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
