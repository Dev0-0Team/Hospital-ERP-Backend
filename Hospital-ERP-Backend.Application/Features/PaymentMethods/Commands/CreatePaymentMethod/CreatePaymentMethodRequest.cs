using MediatR;

namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.CreatePaymentMethod
{
    public record CreatePaymentMethodRequest : IRequest<CreatePaymentMethodResponse>
    {
        public string Name { get; set; } = null!;
    }
}
