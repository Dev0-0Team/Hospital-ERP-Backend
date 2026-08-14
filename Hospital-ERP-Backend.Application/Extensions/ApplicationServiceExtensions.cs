using Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Extensions;
using Hospital_ERP_Backend.Application.Features.Allergies.Extensions;
using Hospital_ERP_Backend.Application.Features.AppointmentQueues.Extensions;
using Hospital_ERP_Backend.Application.Features.Appointments.Extensions;
using Hospital_ERP_Backend.Application.Features.Authentication.Commands;
using Hospital_ERP_Backend.Application.Features.Beds.Extensions;
using Hospital_ERP_Backend.Application.Features.ChronicDiseases.Extensions;
using Hospital_ERP_Backend.Application.Features.Departments.Extensions;
using Hospital_ERP_Backend.Application.Features.Doctors.Extensions;
using Hospital_ERP_Backend.Application.Features.DoctorSchedules.Extensions;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Extensions;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Extensions;
using Hospital_ERP_Backend.Application.Features.EmergencyContacts.Extensions;
using Hospital_ERP_Backend.Application.Features.InvoiceItems.Extensions;
using Hospital_ERP_Backend.Application.Features.Invoices.Extensions;
using Hospital_ERP_Backend.Application.Features.LabOrders.Extensions;
using Hospital_ERP_Backend.Application.Features.LabTestResults.Extensions;
using Hospital_ERP_Backend.Application.Features.LabTests.Extensions;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Extensions;
using Hospital_ERP_Backend.Application.Features.MedicationInventories.Extensions;
using Hospital_ERP_Backend.Application.Features.Medications.Extensions;
using Hospital_ERP_Backend.Application.Features.Notifications.Extensions;
using Hospital_ERP_Backend.Application.Features.Nurses.Extensions;
using Hospital_ERP_Backend.Application.Features.Patients.Extensions;
using Hospital_ERP_Backend.Application.Features.PaymentMethods.Extensions;
using Hospital_ERP_Backend.Application.Features.Payments.Extensions;
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
using Hospital_ERP_Backend.Application.Features.RoomAssignments.Extensions;
using Hospital_ERP_Backend.Application.Features.Rooms.Extensions;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Extensions;
using Hospital_ERP_Backend.Application.Features.Specializations.Extensions;
using Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Extensions;
using Hospital_ERP_Backend.Application.Features.UserRoles.Extensions;
using Hospital_ERP_Backend.Application.Features.Users.Extensions;
using Hospital_ERP_Backend.Application.Security;
using Microsoft.Extensions.Configuration;
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
            services.AddPaymentMethodServicesExtension();
            services.AddPatientServiceExtensions();
            services.AddRoomAssignmentServicesExtension();
            services.AddAppointmentQueueServicesExtension();
            services.AddDoctorScheduleServicesExtension();
            services.AddEmergencyContactsServicesExtension();
            services.AddEmergencyCasesServicesExtension();
            services.AddChronicDiseaseServicesExtension();
            services.AddMedicalRecordServicesExtension();
            services.AddPaymentServicesExtension();
            services.AddNotificationsServicesExtension();
            services.AddInvoiceItemsServicesExtension();
            services.AddInvoiceServicesExtension();
            services.AddAdministrativeStaffServicesExtension();
            services.AddAllergyServicesExtension();
            services.AddJwtTokenServicesExtension(services.BuildServiceProvider().GetRequiredService<IConfiguration>());
            services.AddAuthServiceExtension();
            services.AddSurgeriesHistoryServicesExtension();
            return services;
        }
    }
}