using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Commands.CreateRadiologyOrder
{
    public record CreateRadiologyOrderRequest : IRequest<CreateRadiologyOrderResponse>
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Type { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime OrderedAt { get; set; }
    }
}