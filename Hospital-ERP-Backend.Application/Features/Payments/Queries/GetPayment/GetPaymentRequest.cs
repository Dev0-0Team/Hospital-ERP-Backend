

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Payments.Queries.GetPayment
{
    public record GetPaymentRequest : IRequest<GetPaymentResponse>
    {
        public int Id { get; set; }
    }
}
