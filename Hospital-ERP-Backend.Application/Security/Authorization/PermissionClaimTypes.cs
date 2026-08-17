using Hospital_ERP_Backend.Domain.Enums.PermissionBits;

namespace Hospital_ERP_Backend.Application.Security.Authorization;

public static class PermissionClaimTypes
{
    private static readonly Dictionary<Type, string> Claims = new()
    {
        [typeof(SecurityPermissions)] = "security_permissions",
        [typeof(PatientManagementPermissions)] = "patient_permissions",
        [typeof(MedicalRecordsPermissions)] = "medical_permissions",
        [typeof(AppointmentAndQueuePermissions)] = "appointment_permissions",
        [typeof(StaffManagementPermissions)] = "staff_permissions",
        [typeof(LaboratoryPermissions)] = "laboratory_permissions",
        [typeof(RadiologyPermissions)] = "radiology_permissions",
        [typeof(PharmacyPermissions)] = "pharmacy_permissions",
        [typeof(BillingPermissions)] = "billing_permissions",
        [typeof(HospitalFacilityPermissions)] = "hospital_permissions",
        [typeof(NotificationPermissions)] = "notification_permissions"
    };

    public static string GetClaimType(Type permissionType)
    {
        if (Claims.TryGetValue(permissionType, out var claimType))
        {
            return claimType;
        }

        throw new InvalidOperationException(
            $"No permission claim mapping exists for '{permissionType.FullName}'.");
    }
}