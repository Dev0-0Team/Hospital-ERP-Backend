using Hospital_ERP_Backend.Application.Features.AppointmentQueues.Extensions;
using Hospital_ERP_Backend.Application.Features.Appointments.Extensions;
using Hospital_ERP_Backend.Application.Features.Beds.Extensions;
using Hospital_ERP_Backend.Application.Features.Departments.Extensions;
using Hospital_ERP_Backend.Application.Features.Doctors.Extensions;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Extensions;
using Hospital_ERP_Backend.Application.Features.LabOrders.Extensions;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Extensions;
using Hospital_ERP_Backend.Application.Features.LabTests.Extensions;
using Hospital_ERP_Backend.Application.Features.MedicationInventories.Extensions;
using Hospital_ERP_Backend.Application.Features.Medications.Extensions;
using Hospital_ERP_Backend.Application.Features.Nurses.Extensions;
using Hospital_ERP_Backend.Application.Features.Permissions.Extensions;
using Hospital_ERP_Backend.Application.Features.Persons.Extensions;
using Hospital_ERP_Backend.Application.Features.PrescriptionItems.Extensions;
using Hospital_ERP_Backend.Application.Features.Prescriptions.Extensions;
using Hospital_ERP_Backend.Application.Features.QueuePriorities.Extensions;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Extensions;
using Hospital_ERP_Backend.Application.Features.RadiologyOrders.Extensions;
using Hospital_ERP_Backend.Application.Features.RadiologyReports.Extensions;
using Hospital_ERP_Backend.Application.Features.RolePermissions.Extensions;
using Hospital_ERP_Backend.Application.Features.Roles.Extensions;
using Hospital_ERP_Backend.Application.Features.Rooms.Extensions;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Extensions;
using Hospital_ERP_Backend.Application.Features.Specializations.Extensions;
using Hospital_ERP_Backend.Application.Features.UserRoles.Extensions;
using Hospital_ERP_Backend.Application.Features.Users.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServicesExtension(this IServiceCollection services)
        {
            services.AddPersonServicesExtension();
            services.AddRoleServicesExtension();
            services.AddPermissionServicesExtension();
            services.AddUserServicesExtension();
            services.AddUserRoleServicesExtension();
            services.AddRoomTypeServicesExtension();
            services.AddRoomServicesExtension();
            services.AddRolePermissionServicesExtension();
            services.AddMedicationServicesExtension();
            services.AddLabTestsServicesExtension();
            services.AddQueuePriorityServicesExtension();
            services.AddMedicationInventoryServicesExtensions();
            services.AddDrugInteractionsServicesExtension();
            services.AddPrescriptionsServicesExtension();
            services.AddPrescriptionItemsServicesExtension();
            services.AddLabOrdersServicesExtension();
            services.AddDepartmentServicesExtension();
            services.AddAppointmentServicesExtension();
            services.AddBedServicesExtension();
            services.AddRadiologyReportsServicesExtension();
            services.AddRadiologyImageServicesExtension();
            services.AddLabTestResultsServiceExtension();
            services.AddRadiologyOrdersServicesExtension();
            services.AddDoctorsServicesExtension();
            services.AddSpecializationServicesExtension();
            services.AddNurseServiceExtensions();
            services.AddAppointmentQueueServicesExtension();

            return services;
        }
    }
}