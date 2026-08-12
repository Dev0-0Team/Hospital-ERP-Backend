namespace Hospital_ERP_Backend.Domain.Enums.PermissionBits
{
    [Flags]
    public enum StaffManagementPermissions : ulong
    {
        None = 0,

        DoctorsCreate = 1UL << 0,
        DoctorsRead = 1UL << 1,
        DoctorsUpdate = 1UL << 2,
        DoctorsDelete = 1UL << 3,

        DoctorsManage = DoctorsCreate | DoctorsRead | DoctorsUpdate | DoctorsDelete,

        NursesCreate = 1UL << 4,
        NursesRead = 1UL << 5,
        NursesUpdate = 1UL << 6,
        NursesDelete = 1UL << 7,

        NursesManage = NursesCreate | NursesRead | NursesUpdate | NursesDelete,

        AdministrativeStaffCreate = 1UL << 8,
        AdministrativeStaffRead = 1UL << 9,
        AdministrativeStaffUpdate = 1UL << 10,
        AdministrativeStaffDelete = 1UL << 11,

        AdministrativeStaffManage = AdministrativeStaffCreate | AdministrativeStaffRead | AdministrativeStaffUpdate | AdministrativeStaffDelete,

        DepartmentsCreate = 1UL << 12,
        DepartmentsRead = 1UL << 13,
        DepartmentsUpdate = 1UL << 14,
        DepartmentsDelete = 1UL << 15,

        DepartmentsManage = DepartmentsCreate | DepartmentsRead | DepartmentsUpdate | DepartmentsDelete,

        SpecializationsCreate = 1UL << 16,
        SpecializationsRead = 1UL << 17,
        SpecializationsUpdate = 1UL << 18,
        SpecializationsDelete = 1UL << 19,

        SpecializationsManage = SpecializationsCreate | SpecializationsRead | SpecializationsUpdate | SpecializationsDelete

    }
}
