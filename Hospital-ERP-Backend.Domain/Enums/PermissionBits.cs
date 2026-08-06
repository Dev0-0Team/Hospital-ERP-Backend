namespace Hospital_ERP_Backend.Domain.Enums
{
    [Flags]
    public enum PermissionBits : ulong
    {
        None = 0,

        // Patients
        PatientCreate = 1UL << 0,
        PatientView = 1UL << 1,
        PatientUpdate = 1UL << 2,
        PatientDelete = 1UL << 3,


        // Doctors
        DoctorCreate = 1UL << 4,
        DoctorView = 1UL << 5,
        DoctorUpdate = 1UL << 6,
        DoctorDelete = 1UL << 7,

        // Nurses
        NurseCreate = 1UL << 8,
        NurseView = 1UL << 9,
        NurseUpdate = 1UL << 10,
        NurseDelete = 1UL << 11,

        // Administrative Staff
        AdministrativeStaffCreate = 1UL << 12,
        AdministrativeStaffView = 1UL << 13,
        AdministrativeStaffUpdate = 1UL << 14,
        AdministrativeStaffDelete = 1UL << 15,

        // Appointments
        AppointmentCreate = 1UL << 16,
        AppointmentView = 1UL << 17,
        AppointmentUpdate = 1UL << 18,
        AppointmentDelete = 1UL << 19,

        // Medical Records
        MedicalRecordCreate = 1UL << 20,
        MedicalRecordView = 1UL << 21,
        MedicalRecordUpdate = 1UL << 22,
        MedicalRecordDelete = 1UL << 23,

        // Rooms
        RoomCreate = 1UL << 24,
        RoomView = 1UL << 25,
        RoomUpdate = 1UL << 26,
        RoomDelete = 1UL << 27,

        // Emergency Cases
        EmergencyCaseCreate = 1UL << 28,
        EmergencyCaseView = 1UL << 29,
        EmergencyCaseUpdate = 1UL << 30,
        EmergencyCaseDelete = 1UL << 31,

        // Pharmacy
        MedicationCreate = 1UL << 32,
        MedicationView = 1UL << 33,
        MedicationUpdate = 1UL << 34,
        MedicationDelete = 1UL << 35,

        // Prescriptions
        PrescriptionCreate = 1UL << 36,
        PrescriptionView = 1UL << 37,
        PrescriptionUpdate = 1UL << 38,
        PrescriptionDelete = 1UL << 39,

        // Lab
        LabOrderCreate = 1UL << 40,
        LabOrderView = 1UL << 41,
        LabOrderUpdate = 1UL << 42,
        LabOrderDelete = 1UL << 43,

        // Radiology
        RadiologyOrderCreate = 1UL << 44,
        RadiologyOrderView = 1UL << 45,
        RadiologyOrderUpdate = 1UL << 46,
        RadiologyOrderDelete = 1UL << 47,

        // Billing
        InvoiceCreate = 1UL << 48,
        InvoiceView = 1UL << 49,
        InvoiceUpdate = 1UL << 50,
        InvoiceDelete = 1UL << 51,

        // Security
        UserManage = 1UL << 52,
        RoleManage = 1UL << 53,
        PermissionManage = 1UL << 54,

        // Allergy
        AllergyCreate = 1UL << 55,
        AllergyView = 1UL << 56,
        AllergyUpdate = 1UL << 57,
        AllergyDelete = 1UL << 58,

        // AppointmentQueue
        AppointmentQueueCreate = 1UL << 59,
        AppointmentQueueView = 1UL << 60,
        AppointmentQueueUpdate = 1UL << 61,
        AppointmentQueueDelete = 1UL << 62,

        // Bed
        BedCreate = 1UL << 63,
        BedView = 1UL << 64,
        BedUpdate = 1UL << 65,
        BedDelete = 1UL << 66,

        // ChronicDisease 
        ChronicDiseaseCreate = 1UL << 67,
        ChronicDiseaseView = 1UL << 68,
        ChronicDiseaseUpdate = 1UL << 69,
        ChronicDiseaseDelete = 1UL << 70,

        // Department 
        DepartmentCreate = 1UL << 71,
        DepartmentView = 1UL << 72,
        DepartmentUpdate = 1UL << 73,
        DepartmentDelete = 1UL << 74,

        // DoctorSchedule
        DoctorScheduleCreate = 1UL << 75,
        DoctorScheduleView = 1UL << 76,
        DoctorScheduleUpdate = 1UL << 77,
        DoctorScheduleDelete = 1UL << 78,

        // DrugInteraction 
        DrugInteractionCreate = 1UL << 79,
        DrugInteractionView = 1UL << 80,
        DrugInteractionUpdate = 1UL << 81,
        DrugInteractionDelete = 1UL << 82,

        // EmergencyContact
        EmergencyContactCreate = 1UL << 83,
        EmergencyContactView = 1UL << 84,
        EmergencyContactUpdate = 1UL << 85,
        EmergencyContactDelete = 1UL << 86,

        // InvoiceItem 
        InvoiceItemCreate = 1UL << 87,
        InvoiceItemView = 1UL << 88,
        InvoiceItemUpdate = 1UL << 89,
        InvoiceItemDelete = 1UL << 90,

        // LabTest
        LabTestCreate = 1UL << 91,
        LabTestView = 1UL << 92,
        LabTestUpdate = 1UL << 93,
        LabTestDelete = 1UL << 94,

        // LabOrderResult
        LabOrderResultCreate = 1UL << 95,
        LabOrderResultView = 1UL << 96,
        LabOrderResultUpdate = 1UL << 97,
        LabOrderResultDelete = 1UL << 98,

        // LabTestResult
        LabTestResultCreate = 1UL << 99,
        LabTestResultView = 1UL << 100,
        LabTestResultUpdate = 1UL << 101,
        LabTestResultDelete = 1UL << 102,

        // MedicalInventory
        MedicalInventoryCreate = 1UL << 103,
        MedicalInventoryView = 1UL << 104,
        MedicalInventoryUpdate = 1UL << 105,
        MedicalInventoryDelete = 1UL << 106,

        // Notification 
        NotificationCreate = 1UL << 107,
        NotificationView = 1UL << 108,
        NotificationUpdate = 1UL << 109,
        NotificationDelete = 1UL << 110,

        // Payment 
        PaymentCreate = 1UL << 111,
        PaymentView = 1UL << 112,
        PaymentUpdate = 1UL << 113,
        PaymentDelete = 1UL << 114,

        // PaymentMethod 
        PaymentMethodCreate = 1UL << 115,
        PaymentMethodView = 1UL << 116,
        PaymentMethodUpdate = 1UL << 117,
        PaymentMethodDelete = 1UL << 118,

        // Permission 
        PermissionCreate = 1UL << 119,
        PermissionView = 1UL << 120,
        PermissionUpdate = 1UL << 121,
        PermissionDelete = 1UL << 122,

        // Person 
        PersonCreate = 1UL << 123,
        PersonView = 1UL << 124,
        PersonUpdate = 1UL << 125,
        PersonDelete = 1UL << 126,

        // PrescriptionItem
        PrescriptionItemCreate = 1UL << 127,
        PrescriptionItemView = 1UL << 128,
        PrescriptionItemUpdate = 1UL << 129,
        PrescriptionItemDelete = 1UL << 130,

        // QueuePriority
        QueuePriorityCreate = 1UL << 131,
        QueuePriorityView = 1UL << 132,
        QueuePriorityUpdate = 1UL << 133,
        QueuePriorityDelete = 1UL << 134,

        // RadiologyImage
        RadiologyImageCreate = 1UL << 135,
        RadiologyImageView = 1UL << 136,
        RadiologyImageUpdate = 1UL << 137,
        RadiologyImageDelete = 1UL << 138,

        // RadiologyReport
        RadiologyReportCreate = 1UL << 139,
        RadiologyReportView = 1UL << 140,
        RadiologyReportUpdate = 1UL << 141,
        RadiologyReportDelete = 1UL << 142,

        // Role 
        RoleCreate = 1UL << 143,
        RoleView = 1UL << 144,
        RoleUpdate = 1UL << 145,
        RoleDelete = 1UL << 146,

        // RoomPermission
        RoomPermissionCreate = 1UL << 147,
        RoomPermissionView = 1UL << 148,
        RoomPermissionUpdate = 1UL << 149,
        RoomPermissionDelete = 1UL << 150,

        // RoomAssignment
        RoomAssignmentCreate = 1UL << 151,
        RoomAssignmentView = 1UL << 152,
        RoomAssignmentUpdate = 1UL << 153,
        RoomAssignmentDelete = 1UL << 154,

        // RoomType
        RoomTypeCreate = 1UL << 155,
        RoomTypeView = 1UL << 156,
        RoomTypeUpdate = 1UL << 157,
        RoomTypeDelete = 1UL << 158,

        // Specialization 
        SpecializationCreate = 1UL << 159,
        SpecializationView = 1UL << 160,
        SpecializationUpdate = 1UL << 161,
        SpecializationDelete = 1UL << 162,

        // SurgeriesHistory
        SurgeriesHistoryCreate = 1UL << 163,
        SurgeriesHistoryView = 1UL << 164,
        SurgeriesHistoryUpdate = 1UL << 165,
        SurgeriesHistoryDelete = 1UL << 166,

        // User 
        UserCreate = 1UL << 167,
        UserView = 1UL << 168,
        UserUpdate = 1UL << 169,
        UserDelete = 1UL << 170,

        //UserRole
        UserRoleCreate = 1UL << 171,
        UserRoleView = 1UL << 172,
        UserRoleUpdate = 1UL << 173,
        UserRoleDelete = 1UL << 174





    }
}

