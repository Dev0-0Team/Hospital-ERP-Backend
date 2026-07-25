
namespace Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetInvoice
{
    public record GetInvoiceResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;
    }
}