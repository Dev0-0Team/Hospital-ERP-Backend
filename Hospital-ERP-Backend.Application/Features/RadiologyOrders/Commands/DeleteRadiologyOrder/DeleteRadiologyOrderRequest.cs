using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.DeleteRadiologyOrder
{
    public record DeleteRadiologyOrderRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}