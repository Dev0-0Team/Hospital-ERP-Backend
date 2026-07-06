
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Patient : BaseEntity
{
    public int PersonId { get; set; }

    public string? BloodType { get; set; }

    public ICollection<Allergy> Allergies { get; set; } = new List<Allergy>();

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public ICollection<ChronicDisease> ChronicDiseases { get; set; } = new List<ChronicDisease>();

    public ICollection<EmergencyCase> EmergencyCases { get; set; } = new List<EmergencyCase>();

    public ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public ICollection<LabOrder> LabOrders { get; set; } = new List<LabOrder>();

    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public Person Person { get; set; } = null!;

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public ICollection<RadiologyOrder> RadiologyOrders { get; set; } = new List<RadiologyOrder>();

    public ICollection<RoomAssignment> RoomAssignments { get; set; } = new List<RoomAssignment>();

    public ICollection<SurgeriesHistory> SurgeriesHistories { get; set; } = new List<SurgeriesHistory>();
}
