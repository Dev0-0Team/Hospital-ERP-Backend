

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int PaymentMethodId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaidAt { get; set; }

    public Invoice Invoice { get; set; } = null!;

    public PaymentMethod PaymentMethod { get; set; } = null!;
}
