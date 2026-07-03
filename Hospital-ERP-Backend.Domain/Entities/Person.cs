namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Person : BaseEntity
{
    public string FullName { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Gender { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    public AdministrativeStaff? AdministrativeStaff { get; set; }

    public Doctor? Doctor { get; set; }

    public Nurse? Nurse { get; set; }

    public Patient? Patient { get; set; }

    public User? User { get; set; }
}
