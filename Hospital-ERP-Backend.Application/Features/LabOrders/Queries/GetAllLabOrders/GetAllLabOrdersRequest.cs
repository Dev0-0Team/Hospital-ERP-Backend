using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetAllLabOrders
{
    public record GetAllLabOrdersRequest : IRequest<IEnumerable<GetAllLabOrdersResponse>>
    {
        public int Page { get; set; }
    }
}