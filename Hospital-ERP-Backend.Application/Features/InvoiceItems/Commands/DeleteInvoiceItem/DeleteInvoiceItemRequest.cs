using MediatR;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.DeleteInvoiceItem
{
    public record DeleteInvoiceItemRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}