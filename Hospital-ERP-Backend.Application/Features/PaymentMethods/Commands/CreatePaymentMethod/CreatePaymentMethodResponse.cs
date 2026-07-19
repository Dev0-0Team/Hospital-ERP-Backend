

namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.CreatePaymentMethod
{
    public record CreatePaymentMethodResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
