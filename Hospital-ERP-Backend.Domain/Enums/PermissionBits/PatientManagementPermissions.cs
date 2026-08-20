namespace Hospital_ERP_Backend.Domain.Enums.PermissionBits
{
    [Flags]
    public enum PatientManagementPermissions : ulong
    {
        None = 0,

        PatientCreate = 1UL << 0,
        PatientRead = 1UL << 1,
        PatientUpdate = 1UL << 2,
        PatientDelete = 1UL << 3,

        PatientManage = PatientCreate | PatientRead | PatientUpdate | PatientDelete,


        PersonsCreate = 1UL << 4,
        PersonsRead = 1UL << 5,
        PersonsUpdate = 1UL << 6,
        PersonsDelete = 1UL << 7,

        PersonsManage = PersonsCreate | PersonsRead | PersonsUpdate | PersonsDelete,

        EmergencyContactsCreate = 1UL << 8,
        EmergencyContactsRead = 1UL << 9,
        EmergencyContactsUpdate = 1UL << 10,
        EmergencyContactsDelete = 1UL << 11,

        EmergencyContactsManage = EmergencyContactsCreate | EmergencyContactsRead | EmergencyContactsUpdate | EmergencyContactsDelete,

        AllergiesCreate = 1UL << 12,
        AllergiesRead = 1UL << 13,
        AllergiesUpdate = 1UL << 14,
        AllergiesDelete = 1UL << 15,

        AllergiesManage = AllergiesCreate | AllergiesRead | AllergiesUpdate | AllergiesDelete,

        ChronicDiseasesCreate = 1UL << 16,
        ChronicDiseasesRead = 1UL << 17,
        ChronicDiseasesUpdate = 1UL << 18,
        ChronicDiseasesDelete = 1UL << 19,

        ChronicDiseasesManage = ChronicDiseasesCreate | ChronicDiseasesRead | ChronicDiseasesUpdate | ChronicDiseasesDelete,

        SurgeriesHistoryCreate = 1UL << 20,
        SurgeriesHistoryRead = 1UL << 21,
        SurgeriesHistoryUpdate = 1UL << 22,
        SurgeriesHistoryDelete = 1UL << 23,

        SurgeriesHistoryManage = SurgeriesHistoryCreate | SurgeriesHistoryRead | SurgeriesHistoryUpdate | SurgeriesHistoryDelete,

        EmergencyCasesCreate = 1UL << 24,
        EmergencyCasesRead = 1UL << 25,
        EmergencyCasesUpdate = 1UL << 26,
        EmergencyCasesDelete = 1UL << 27,

        EmergencyCasesManage = EmergencyCasesCreate | EmergencyCasesRead | EmergencyCasesUpdate | EmergencyCasesDelete,

    }


}
