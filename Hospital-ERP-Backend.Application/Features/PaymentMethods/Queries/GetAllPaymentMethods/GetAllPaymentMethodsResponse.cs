
namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetAllPaymentMethods
{
    public record GetAllPaymentMethodsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
