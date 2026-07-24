using Hospital_ERP_Backend.Domain.Enums;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Invoices.Commands.UpdateInvoice
{
    public record UpdateInvoiceRequest : IRequest<UpdateInvoiceResponse>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}
