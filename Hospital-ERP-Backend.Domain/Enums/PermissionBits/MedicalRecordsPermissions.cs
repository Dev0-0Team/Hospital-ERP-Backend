namespace Hospital_ERP_Backend.Domain.Enums.PermissionBits
{
    [Flags]
    public enum MedicalRecordsPermissions : ulong
    {
        None = 0,

        MedicalRecordsCreate = 1UL << 0,
        MedicalRecordsRead = 1UL << 1,
        MedicalRecordsUpdate = 1UL << 2,
        MedicalRecordsDelete = 1UL << 3,

        MedicalRecordsManage = MedicalRecordsCreate | MedicalRecordsRead | MedicalRecordsUpdate | MedicalRecordsDelete,

        LabTestResultsCreate = 1UL << 4,
        LabTestResultsRead = 1UL << 5,
        LabTestResultsUpdate = 1UL << 6,
        LabTestResultsDelete = 1UL << 7,

        LabTestResultsManage = LabTestResultsCreate | LabTestResultsRead | LabTestResultsUpdate | LabTestResultsDelete
    }
}
