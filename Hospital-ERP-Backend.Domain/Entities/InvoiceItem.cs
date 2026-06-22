
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class InvoiceItem
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public string ItemName { get; set; } = null!;

    public decimal Amount { get; set; }

    public string ReferenceType { get; set; } = null!;

    public int ReferenceId { get; set; }

    public Invoice Invoice { get; set; } = null!;
}
