
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetAllPaymentMethods
{
    public record GetAllPaymentMethodsRequest : IRequest<IEnumerable<GetAllPaymentMethodsResponse>>
    {
        public int Page { get; set; }
    }
}
