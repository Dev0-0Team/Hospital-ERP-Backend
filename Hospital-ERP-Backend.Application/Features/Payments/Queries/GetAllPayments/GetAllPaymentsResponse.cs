
namespace Hospital_ERP_Backend.Application.Features.Payments.Queries.GetAllPayments
{
    public record GetAllPaymentsResponse
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
    }
}
