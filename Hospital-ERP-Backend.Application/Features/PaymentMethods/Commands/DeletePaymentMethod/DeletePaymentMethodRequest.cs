using MediatR;


namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.DeletePaymentMethod
{
    public record DeletePaymentMethodRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
