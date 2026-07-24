using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Invoices.Commands.CreateInvoice
{
    public record CreateInvoiceRequest : IRequest<CreateInvoiceResponse>
    {
        public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;
    }
}
