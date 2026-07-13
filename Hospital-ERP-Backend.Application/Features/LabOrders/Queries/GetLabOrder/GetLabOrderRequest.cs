using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetLabOrder
{
    public record GetLabOrderRequest : IRequest<GetLabOrderResponse>
    {
        public int Id { get; set; }
    }
}