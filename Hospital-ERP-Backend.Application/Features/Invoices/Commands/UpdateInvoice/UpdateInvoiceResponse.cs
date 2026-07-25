

namespace Hospital_ERP_Backend.Application.Features.Invoices.Commands.UpdateInvoice
{
    public record UpdateInvoiceResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;
    }
}
