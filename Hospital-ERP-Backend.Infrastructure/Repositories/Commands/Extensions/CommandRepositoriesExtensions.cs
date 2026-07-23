using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Extensions
{
    public static class CommandRepositoriesExtensions
    {
        public static IServiceCollection AddCommandRepositoriesExtension(this IServiceCollection services)
        {
            services.AddScoped<IBaseCommandRepository<Person>, PersonCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Role>, RoleCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Permission>, PermissionCommandRepository>();
            services.AddScoped<IBaseCommandRepository<User>, UserCommandRepository>();
            services.AddScoped<IBaseCommandRepository<UserRole>, UserRoleCommandRepository>();
            services.AddScoped<IBaseCommandRepository<RolePermission>, RolePermissionCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Medication>, MedicationCommandRepository>();
            services.AddScoped<IBaseCommandRepository<RoomType>, RoomTypeCommandRepository>();
            services.AddScoped<IBaseCommandRepository<LabTest>, LabTestCommandRepository>();
            services.AddScoped<IBaseCommandRepository<QueuePriority>, QueuePriorityCommandRepository>();
            services.AddScoped<IBaseCommandRepository<MedicationInventory>, MedicationInventoryCommandRepository>();
            services.AddScoped<IBaseCommandRepository<DrugInteraction>, DrugInteractionCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Room>, RoomCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Prescription>, PrescriptionCommandRepository>();
            services.AddScoped<IBaseCommandRepository<PrescriptionItem>, PrescriptionItemCommandRepository>();
            services.AddScoped<IBaseCommandRepository<LabOrder>, LabOrdersCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Appointment>, AppointmentCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Department>, DepartmentCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Bed>, BedCommandRepository>();
            services.AddScoped<IBaseCommandRepository<RadiologyReport>, RadiologyReportCommandRepository>();
            services.AddScoped<IBaseCommandRepository<RadiologyImage>, RadiologyImageCommandRepositroy>();
            services.AddScoped<IBaseCommandRepository<LabTestResult>, LabTestResultCommandReposaitory>();
            services.AddScoped<IBaseCommandRepository<RadiologyOrder>, RadiologyOrderCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Doctor>, DoctorCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Specialization>, SpecializationCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Nurse>, NurseCommandRepository>();
            services.AddScoped<IBaseCommandRepository<PaymentMethod>, PaymentMethodCommandRepository>();
            services.AddScoped<IBaseCommandRepository<RoomAssignment>, RoomAssignmentCommandRepository>();
            services.AddScoped<IBaseCommandRepository<AppointmentQueue>, AppointmentQueueCommandRepository>();
            services.AddScoped<IBaseCommandRepository<DoctorSchedule>, DoctorScheduleCommandRepository>();
            services.AddScoped<IBaseCommandRepository<EmergencyContact>, EmergencyContactCommandRepository>();
            services.AddScoped<IBaseCommandRepository<ChronicDisease>, ChronicDiseaseCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Patient>, PatientCommandRepository>();
            services.AddScoped<IBaseCommandRepository<MedicalRecord>, MedicalRecordCommandRepository>();
            services.AddScoped<IBaseCommandRepository<Payment>, PaymentCommandRepository>();
            return services;
        }
    }
}