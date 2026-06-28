
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Department : BaseEntity
{

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<AdministrativeStaff> AdministrativeStaffs { get; set; } = new List<AdministrativeStaff>();

    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public ICollection<Nurse> Nurses { get; set; } = new List<Nurse>();

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}
