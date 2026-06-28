

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Invoice : BaseEntity
{
    public int PatientId { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public Patient Patient { get; set; } = null!;

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
