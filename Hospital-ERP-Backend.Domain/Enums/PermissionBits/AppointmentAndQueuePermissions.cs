namespace Hospital_ERP_Backend.Domain.Enums.PermissionBits
{
    [Flags]
    public enum AppointmentAndQueuePermissions : ulong
    {
        None = 0,

        AppointmentsCreate = 1UL << 0,
        AppointmentsRead = 1UL << 1,
        AppointmentsUpdate = 1UL << 2,
        AppointmentsDelete = 1UL << 3,

        AppointmentsManage = AppointmentsCreate | AppointmentsRead | AppointmentsUpdate | AppointmentsDelete,

        AppointmentsQueueCreate = 1UL << 4,
        AppointmentsQueueRead = 1UL << 5,
        AppointmentsQueueUpdate = 1UL << 6,
        AppointmentsQueueDelete = 1UL << 7,

        AppointmentsQueueManage = AppointmentsQueueCreate | AppointmentsQueueRead | AppointmentsQueueUpdate | AppointmentsQueueDelete,

        QueuePrioritiesCreate = 1UL << 8,
        QueuePrioritiesRead = 1UL << 9,
        QueuePrioritiesUpdate = 1UL << 10,
        QueuePrioritiesDelete = 1UL << 11,

        QueuePrioritiesManage = QueuePrioritiesCreate | QueuePrioritiesRead | QueuePrioritiesUpdate | QueuePrioritiesDelete,

        DoctorSchedulesCreate = 1UL << 12,
        DoctorSchedulesRead = 1UL << 13,
        DoctorSchedulesUpdate = 1UL << 14,
        DoctorSchedulesDelete = 1UL << 15,

        DoctorSchedulesManage = DoctorSchedulesCreate | DoctorSchedulesRead | DoctorSchedulesUpdate | DoctorSchedulesDelete


    }
}
