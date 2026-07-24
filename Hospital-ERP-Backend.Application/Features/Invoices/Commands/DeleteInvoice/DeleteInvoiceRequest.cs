
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
