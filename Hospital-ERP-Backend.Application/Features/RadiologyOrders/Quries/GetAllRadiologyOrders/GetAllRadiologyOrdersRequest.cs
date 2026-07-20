using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetAllRadiologyOrders
{
    public record GetAllRadiologyOrdersRequest
        : IRequest<IEnumerable<GetAllRadiologyOrdersResponse>>
    {
        public int Page { get; set; }
    }
}