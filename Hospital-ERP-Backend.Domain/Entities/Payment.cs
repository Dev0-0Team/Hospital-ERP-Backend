

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Payment : BaseEntity
{
    public int InvoiceId { get; set; }

    public int PaymentMethodId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaidAt { get; set; }

    public Invoice Invoice { get; set; } = null!;

    public PaymentMethod PaymentMethod { get; set; } = null!;
}
