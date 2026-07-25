using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetInvoice
{
    public record GetInvoiceRequest : IRequest<GetInvoiceResponse>
    {
        public int Id { get; set; }
    }
}