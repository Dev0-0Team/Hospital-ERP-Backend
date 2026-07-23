

namespace Hospital_ERP_Backend.Application.Features.Payments.Commands.UpdatePayment
{
    public record UpdatePaymentResponse
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }

        public int PaymentMethodId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaidAt { get; set; }
    }
}
