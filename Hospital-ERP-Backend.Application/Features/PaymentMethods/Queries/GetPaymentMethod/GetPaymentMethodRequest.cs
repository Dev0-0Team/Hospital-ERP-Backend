using MediatR;


namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetPaymentMethod
{
    public record GetPaymentMethodRequest : IRequest<GetPaymentMethodResponse>
    {
        public int Id { get; set; }
    }
}
