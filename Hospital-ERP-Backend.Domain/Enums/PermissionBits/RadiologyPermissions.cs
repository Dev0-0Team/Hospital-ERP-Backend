namespace Hospital_ERP_Backend.Domain.Enums.PermissionBits
{
    [Flags]
    public enum RadiologyPermissions : ulong
    {
        None = 0,

        RadiologyOrdersCreate = 1UL << 0,
        RadiologyOrdersRead = 1UL << 1,
        RadiologyOrdersUpdate = 1UL << 2,
        RadiologyOrdersDelete = 1UL << 3,

        RadiologyOrdersManage = RadiologyOrdersCreate | RadiologyOrdersRead | RadiologyOrdersUpdate | RadiologyOrdersDelete,

        RadiologyReportsCreate = 1UL << 4,
        RadiologyReportsRead = 1UL << 5,
        RadiologyReportsUpdate = 1UL << 6,
        RadiologyReportsDelete = 1UL << 7,

        RadiologyReportsManage = RadiologyReportsCreate | RadiologyReportsRead | RadiologyReportsUpdate | RadiologyReportsDelete,

        RadiologyImagesCreate = 1UL << 8,
        RadiologyImagesRead = 1UL << 9,
        RadiologyImagesUpdate = 1UL << 10,
        RadiologyImagesDelete = 1UL << 11,

        RadiologyImagesManage = RadiologyImagesCreate | RadiologyImagesRead | RadiologyImagesUpdate | RadiologyImagesDelete,

    }
}
