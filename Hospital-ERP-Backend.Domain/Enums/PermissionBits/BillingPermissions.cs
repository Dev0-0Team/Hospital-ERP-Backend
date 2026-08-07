namespace Hospital_ERP_Backend.Domain.Enums.PermissionBits
{
    [Flags]
    public enum BillingPermissions : ulong
    {
        None = 0,

        InvoicesCreate = 1UL << 0,
        InvoicesRead = 1UL << 1,
        InvoicesUpdate = 1UL << 2,
        InvoicesDelete = 1UL << 3,

        InvoicesManage = InvoicesCreate | InvoicesRead | InvoicesUpdate | InvoicesDelete,

        PaymentsCreate = 1UL << 4,
        PaymentsRead = 1UL << 5,
        PaymentsUpdate = 1UL << 6,
        PaymentsDelete = 1UL << 7,

        PaymentsManage = PaymentsCreate | PaymentsRead | PaymentsUpdate | PaymentsDelete,

        InvoiceItemsCreate = 1UL << 8,
        InvoiceItemsRead = 1UL << 9,
        InvoiceItemsUpdate = 1UL << 10,
        InvoiceItemsDelete = 1UL << 11,

        InvoiceItemsManage = InvoiceItemsCreate | InvoiceItemsRead | InvoiceItemsUpdate | InvoiceItemsDelete,

        PaymentMethodsCreate = 1UL << 12,
        PaymentMethodsRead = 1UL << 13,
        PaymentMethodsUpdate = 1UL << 14,
        PaymentMethodsDelete = 1UL << 15,

        PaymentMethodsManage = PaymentMethodsCreate | PaymentMethodsRead | PaymentMethodsUpdate | PaymentMethodsDelete

    }
}
