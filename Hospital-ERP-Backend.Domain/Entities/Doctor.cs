
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Doctor : BaseEntity
{
    public int PersonId { get; set; }

    public int DepartmentId { get; set; }

    public int SpecializationId { get; set; }

    public string LicenseNumber { get; set; } = null!;


    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public Department Department { get; set; } = null!;

    public ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();

    public ICollection<LabOrder> LabOrders { get; set; } = new List<LabOrder>();

    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public Person Person { get; set; } = null!;

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public ICollection<RadiologyOrder> RadiologyOrders { get; set; } = new List<RadiologyOrder>();

    public Specialization Specialization { get; set; } = null!;
}
