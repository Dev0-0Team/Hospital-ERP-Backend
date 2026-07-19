using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
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
            services.AddScoped<IBaseQueryRepository<User>, UserQueryRepository>();
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
            return services;
        }
    }
}