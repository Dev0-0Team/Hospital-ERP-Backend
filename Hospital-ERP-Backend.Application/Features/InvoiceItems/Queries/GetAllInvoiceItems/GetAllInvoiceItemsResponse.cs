namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Queries.GetAllInvoiceItems
{
    public record GetAllInvoiceItemsResponse
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string ReferenceType { get; set; } = string.Empty;

        public int ReferenceId { get; set; }
    }
}