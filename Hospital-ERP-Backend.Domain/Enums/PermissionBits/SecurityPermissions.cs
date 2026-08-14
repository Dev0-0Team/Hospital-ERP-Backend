namespace Hospital_ERP_Backend.Domain.Enums.PermissionBits
{
    [Flags]
    public enum SecurityPermissions : ulong
    {

        None = 0,

        UserCreate = 1UL << 0,
        UserRead = 1UL << 1,
        UserUpdate = 1UL << 2,
        UserDelete = 1UL << 3,

        UserManage = UserCreate | UserRead | UserUpdate | UserDelete,

        RolesCreate = 1UL << 4,
        RolesRead = 1UL << 5,
        RolesUpdate = 1UL << 6,
        RolesDelete = 1UL << 7,

        RolesManage = RolesCreate | RolesRead | RolesUpdate | RolesDelete,

        PermissionsCreate = 1UL << 8,
        PermissionsRead = 1UL << 9,
        PermissionsUpdate = 1UL << 10,
        PermissionsDelete = 1UL << 11,

        PermissionsManage = PermissionsCreate | PermissionsRead | PermissionsUpdate | PermissionsDelete,

        UserRolesCreate = 1UL << 12,
        UserRolesRead = 1UL << 13,
        UserRolesUpdate = 1UL << 14,
        UserRolesDelete = 1UL << 15,

        UserRolesManage = UserRolesCreate | UserRolesRead | UserRolesUpdate | UserRolesDelete,

        RolePermissionsCreate = 1UL << 16,
        RolePermissionsRead = 1UL << 17,
        RolePermissionsUpdate = 1UL << 18,
        RolePermissionsDelete = 1UL << 19,

        RolePermissionsManage = RolePermissionsCreate | RolePermissionsRead | RolePermissionsUpdate | RolePermissionsDelete,
    }
}
