namespace Hospital_ERP_Backend.Domain.Enums.PermissionBits
{
    [Flags]
    public enum LaboratoryPermissions : ulong
    {
        None = 0,

        LabTestsCreate = 1UL << 0,
        LabTestsRead = 1UL << 1,
        LabTestsUpdate = 1UL << 2,
        LabTestsDelete = 1UL << 3,

        LabTestsManage = LabTestsCreate | LabTestsRead | LabTestsUpdate | LabTestsDelete,

        LabOrdersCreate = 1UL << 4,
        LabOrdersRead = 1UL << 5,
        LabOrdersUpdate = 1UL << 6,
        LabOrdersDelete = 1UL << 7,

        LabOrdersManage = LabOrdersCreate | LabOrdersRead | LabOrdersUpdate | LabOrdersDelete,

    }
}
