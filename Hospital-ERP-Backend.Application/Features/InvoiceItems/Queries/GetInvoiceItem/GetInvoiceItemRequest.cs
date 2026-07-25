using MediatR;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Queries.GetInvoiceItem
{
    public record GetInvoiceItemRequest : IRequest<GetInvoiceItemResponse>
    {
        public int Id { get; set; }
    }
}