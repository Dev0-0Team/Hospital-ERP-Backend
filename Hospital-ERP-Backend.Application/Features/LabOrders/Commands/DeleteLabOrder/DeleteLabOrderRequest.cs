using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Commands.DeleteLabOrder
{
    public record DeleteLabOrderRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}