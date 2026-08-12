namespace Hospital_ERP_Backend.Domain.Enums.PermissionBits
{
    [Flags]
    public enum NotificationPermissions : ulong
    {
        None = 0,

        NotificationsCreate = 1UL << 0,
        NotificationsRead = 1UL << 1,
        NotificationsUpdate = 1UL << 2,
        NotificationsDelete = 1UL << 3,

        NotificationsManage = NotificationsCreate | NotificationsRead | NotificationsUpdate | NotificationsDelete
    }
}

