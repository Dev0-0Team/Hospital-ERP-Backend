namespace Hospital_ERP_Backend.Domain.Enums.PermissionBits
{
    [Flags]
    public enum HospitalFacilityPermissions : ulong
    {
        None = 0,

        RoomsCreate = 1UL << 0,
        RoomsRead = 1UL << 1,
        RoomsUpdate = 1UL << 2,
        RoomsDelete = 1UL << 3,

        RoomsManage = RoomsCreate | RoomsRead | RoomsUpdate | RoomsDelete,

        RoomsTypeCreate = 1UL << 4,
        RoomsTypeRead = 1UL << 5,
        RoomsTypeUpdate = 1UL << 6,
        RoomsTypeDelete = 1UL << 7,

        RoomsTypeManage = RoomsTypeCreate | RoomsTypeRead | RoomsTypeUpdate | RoomsTypeDelete,

        BedsCreate = 1UL << 8,
        BedsRead = 1UL << 9,
        BedsUpdate = 1UL << 10,
        BedsDelete = 1UL << 11,

        BedsManage = BedsCreate | BedsRead | BedsUpdate | BedsDelete,

        RoomAssignmentsCreate = 1UL << 12,
        RoomAssignmentsRead = 1UL << 13,
        RoomAssignmentsUpdate = 1UL << 14,
        RoomAssignmentsDelete = 1UL << 15,

        RoomAssignmentsManage = RoomAssignmentsCreate | RoomAssignmentsRead | RoomAssignmentsUpdate | RoomAssignmentsDelete


    }
}
