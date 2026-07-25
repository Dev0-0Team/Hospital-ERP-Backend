using MediatR;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.CreateInvoiceItem
{
    public record CreateInvoiceItemRequest : IRequest<CreateInvoiceItemResponse>
    {
        public int InvoiceId { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string ReferenceType { get; set; } = string.Empty;

        public int ReferenceId { get; set; }
    }
}