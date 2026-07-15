using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetRadiologyOrder
{
    public record GetRadiologyOrderRequest
        : IRequest<GetRadiologyOrderResponse>
    {
        public int Id { get; set; }
    }
}