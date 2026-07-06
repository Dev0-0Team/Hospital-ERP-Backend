namespace Hospital_ERP_Backend.Domain.Entities;

public partial class SurgeriesHistory : BaseEntity
{
    public int PatientId { get; set; }

    public string SurgeryName { get; set; } = null!;

    public DateOnly? SurgeryDate { get; set; }

    public Patient Patient { get; set; } = null!;
}
