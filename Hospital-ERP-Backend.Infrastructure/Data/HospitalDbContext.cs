using Microsoft.EntityFrameworkCore;
using Hospital_ERP_Backend.Domain.Entities;

namespace Hospital_ERP_Backend.Infrastructure.Data;

public partial class HospitalDbContext : DbContext
{
    public HospitalDbContext()
    {
    }

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public DbSet<AdministrativeStaff> AdministrativeStaffs { get; set; }

    public DbSet<Allergy> Allergies { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

    public DbSet<AppointmentQueue> AppointmentQueues { get; set; }

    public DbSet<Bed> Beds { get; set; }

    public DbSet<ChronicDisease> ChronicDiseases { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    public DbSet<DrugInteraction> DrugInteractions { get; set; }

    public DbSet<EmergencyCase> EmergencyCases { get; set; }

    public DbSet<EmergencyContact> EmergencyContacts { get; set; }

    public DbSet<Invoice> Invoices { get; set; }

    public DbSet<InvoiceItem> InvoiceItems { get; set; }

    public DbSet<LabOrder> LabOrders { get; set; }

    public DbSet<LabTest> LabTests { get; set; }

    public DbSet<LabTestResult> LabTestResults { get; set; }

    public DbSet<MedicalRecord> MedicalRecords { get; set; }

    public DbSet<Medication> Medications { get; set; }

    public DbSet<MedicationInventory> MedicationInventories { get; set; }

    public DbSet<Notification> Notifications { get; set; }

    public DbSet<Nurse> Nurses { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<PaymentMethod> PaymentMethods { get; set; }

    public DbSet<Permission> Permissions { get; set; }

    public DbSet<Person> Persons { get; set; }

    public DbSet<Prescription> Prescriptions { get; set; }

    public DbSet<PrescriptionItem> PrescriptionItems { get; set; }

    public DbSet<QueuePriority> QueuePriorities { get; set; }

    public DbSet<RadiologyImage> RadiologyImages { get; set; }

    public DbSet<RadiologyOrder> RadiologyOrders { get; set; }

    public DbSet<RadiologyReport> RadiologyReports { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Room> Rooms { get; set; }

    public DbSet<RoomAssignment> RoomAssignments { get; set; }

    public DbSet<RoomType> RoomTypes { get; set; }

    public DbSet<Specialization> Specializations { get; set; }

    public DbSet<SurgeriesHistory> SurgeriesHistories { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<RolePermission> RolePermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalDbContext).Assembly);
    }
}
