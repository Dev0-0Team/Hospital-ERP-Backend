namespace Hospital_ERP_Backend.Domain.Enums.PermissionBits
{
    [Flags]
    public enum PharmacyPermissions : ulong
    {
        None = 0,

        MedicationsCreate = 1UL << 0,
        MedicationsRead = 1UL << 1,
        MedicationsUpdate = 1UL << 2,
        MedicationsDelete = 1UL << 3,

        MedicationsManage = MedicationsCreate | MedicationsRead | MedicationsUpdate | MedicationsDelete,

        MedicationInventoryCreate = 1UL << 4,
        MedicationInventoryRead = 1UL << 5,
        MedicationInventoryUpdate = 1UL << 6,
        MedicationInventoryDelete = 1UL << 7,

        MedicationInventoryManage = MedicationInventoryCreate | MedicationInventoryRead | MedicationInventoryUpdate | MedicationInventoryDelete,

        PrescriptionsCreate = 1UL << 8,
        PrescriptionsRead = 1UL << 9,
        PrescriptionsUpdate = 1UL << 10,
        PrescriptionsDelete = 1UL << 11,

        PrescriptionsManage = PrescriptionsCreate | PrescriptionsRead | PrescriptionsUpdate | PrescriptionsDelete,

        PrescriptionsItemsCreate = 1UL << 12,
        PrescriptionsItemsRead = 1UL << 13,
        PrescriptionsItemsUpdate = 1UL << 14,
        PrescriptionsItemsDelete = 1UL << 15,

        PrescriptionsItemsManage = PrescriptionsItemsCreate | PrescriptionsItemsRead | PrescriptionsItemsUpdate | PrescriptionsItemsDelete,

        DrugInteractionsCreate = 1UL << 16,
        DrugInteractionsRead = 1UL << 17,
        DrugInteractionsUpdate = 1UL << 18,
        DrugInteractionsDelete = 1UL << 19,

        DrugInteractionManage = DrugInteractionsCreate | DrugInteractionsRead | DrugInteractionsUpdate | DrugInteractionsDelete,


    }
}
