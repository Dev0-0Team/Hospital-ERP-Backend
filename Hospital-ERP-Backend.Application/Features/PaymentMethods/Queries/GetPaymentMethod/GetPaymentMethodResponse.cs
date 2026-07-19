
namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetPaymentMethod
{
    public record GetPaymentMethodResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
