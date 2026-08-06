using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetAllInvoices
{
    public record GetAllInvoicesRequest : IRequest<IEnumerable<GetAllInvoicesResponse>>
    {
        public int Page { get; set; }
    }
}