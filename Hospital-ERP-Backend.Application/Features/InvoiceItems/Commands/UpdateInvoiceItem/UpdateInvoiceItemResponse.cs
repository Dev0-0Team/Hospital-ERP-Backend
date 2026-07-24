namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.UpdateInvoiceItem
{
    public record UpdateInvoiceItemResponse
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string ReferenceType { get; set; } = string.Empty;

        public int ReferenceId { get; set; }
    }
}