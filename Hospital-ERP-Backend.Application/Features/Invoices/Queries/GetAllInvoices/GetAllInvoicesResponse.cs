
namespace Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetAllInvoices
{
    public record GetAllInvoicesResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;
    }
}