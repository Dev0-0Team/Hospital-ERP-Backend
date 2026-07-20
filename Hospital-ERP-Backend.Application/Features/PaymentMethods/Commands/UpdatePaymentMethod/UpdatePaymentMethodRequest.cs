using MediatR;

namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod
{
    public record UpdatePaymentMethodRequest : IRequest<UpdatePaymentMethodResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
