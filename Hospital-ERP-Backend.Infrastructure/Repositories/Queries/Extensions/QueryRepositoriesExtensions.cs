using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Domain.Interfaces.Permission;
using Hospital_ERP_Backend.Domain.Interfaces.User;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Extensions
{
    public static class QueryRepositoriesExtensions
    {
        public static IServiceCollection AddQueryRepositoriesExtension(this IServiceCollection services)
        {
            services.AddScoped<IBaseQueryRepository<Person>, PersonQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Role>, RoleQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Permission>, PermissionQueryRepository>();
            services.AddScoped<IPermissionQueryRepository, PermissionQueryRepository>();
            services.AddScoped<IBaseQueryRepository<User>, UserQueryRepository>();
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
            services.AddScoped<IBaseQueryRepository<UserRole>, UserRoleQueryRepository>();
            services.AddScoped<IBaseQueryRepository<RolePermission>, RolePermissionQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Medication>, MedicationQueryRepository>();
            services.AddScoped<IBaseQueryRepository<RoomType>, RoomTypeQueryRepository>();
            services.AddScoped<IBaseQueryRepository<QueuePriority>, QueuePriorityQueryRepository>();
            services.AddScoped<IBaseQueryRepository<LabTest>, LabTestQueryRepository>();
            services.AddScoped<IBaseQueryRepository<MedicationInventory>, MedicationInventoryQueryRepository>();
            services.AddScoped<IBaseQueryRepository<DrugInteraction>, DrugInteractionsRepository>();
            services.AddScoped<IBaseQueryRepository<Room>, RoomQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Prescription>, PrescriptionQueryRepository>();
            services.AddScoped<IBaseQueryRepository<PrescriptionItem>, PrescriptionItemQueryRepository>();
            services.AddScoped<IBaseQueryRepository<LabOrder>, LabOrderQueryRespository>();
            services.AddScoped<IBaseQueryRepository<Appointment>, AppointmentQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Department>, DepartmentQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Bed>, BedQueryRepository>();
            services.AddScoped<IBaseQueryRepository<RadiologyReport>, RadiologyReportQueryRepository>();
            services.AddScoped<IBaseQueryRepository<RadiologyImage>, RadiologyImageQueryRepository>();
            services.AddScoped<IBaseQueryRepository<LabTestResult>, LabTestResultQueryRepository>();
            services.AddScoped<IBaseQueryRepository<RadiologyOrder>, RadiologyOrderQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Doctor>, DoctorQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Specialization>, SpecializationQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Nurse>, NurseQueryRepository>();
            services.AddScoped<IBaseQueryRepository<PaymentMethod>, PaymentMethodQueryRepository>();
            services.AddScoped<IBaseQueryRepository<RoomAssignment>, RoomAssignmentQueryRepository>();
            services.AddScoped<IBaseQueryRepository<AppointmentQueue>, AppointmentQueueQueryRepository>();
            services.AddScoped<IBaseQueryRepository<DoctorSchedule>, DoctorScheduleQueryRepository>();
            services.AddScoped<IBaseQueryRepository<EmergencyContact>, EmergencyContactQueryRepository>();
            services.AddScoped<IBaseQueryRepository<EmergencyCase>, EmergencyCasesQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Patient>, PatientQueryRepository>();
            services.AddScoped<IBaseQueryRepository<ChronicDisease>, ChronicDiseaseQueryRepository>();
            services.AddScoped<IBaseQueryRepository<MedicalRecord>, MedicalRecordQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Payment>, PaymentQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Notification>, NotificationQueryRepository>();
            services.AddScoped<IBaseQueryRepository<InvoiceItem>, InvoiceItemQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Invoice>, InvoiceQueryRepository>();
            services.AddScoped<IBaseQueryRepository<AdministrativeStaff>, AdministrativeStaffQueryRepository>();
            services.AddScoped<IBaseQueryRepository<Allergy>, AllergyQueryRepository>();
            services.AddScoped<IBaseQueryRepository<EmergencyCase>, EmergencyCasesQueryRepository>();
            services.AddScoped<IBaseQueryRepository<SurgeriesHistory>, SurgeriesHistoryQueryRepository>();
            services.AddScoped<IBaseQueryRepository<RefreshToken>, RefreshTokenQueryRepository>();
            return services;
        }
    }
}