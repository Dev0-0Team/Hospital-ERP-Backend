

namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod
{
    public record UpdatePaymentMethodResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
