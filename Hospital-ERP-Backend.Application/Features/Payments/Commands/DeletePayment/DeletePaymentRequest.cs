using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Payments.Commands.DeletePayment
{
    public record DeletePaymentRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
