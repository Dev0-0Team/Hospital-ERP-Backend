using MediatR;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Queries.GetAllInvoiceItems
{
    public record GetAllInvoiceItemsRequest : IRequest<IEnumerable<GetAllInvoiceItemsResponse>>
    {
        public int Page { get; set; } = 1;
    }
}