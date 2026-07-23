using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Payments.Queries.GetAllPayments
{
    public record GetAllPaymentsRequest : IRequest<IEnumerable<GetAllPaymentsResponse>>
    {
        public int Page { get; set; }
    }
}
