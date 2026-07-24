using Hospital_ERP_Backend.Domain.Enums;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;
    }
}
