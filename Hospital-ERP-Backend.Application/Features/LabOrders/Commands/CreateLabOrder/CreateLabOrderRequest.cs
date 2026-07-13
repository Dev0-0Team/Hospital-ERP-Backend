using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabOrders.Commands.CreateLabOrder
{
    public record CreateLabOrderRequest : IRequest<CreateLabOrderResponse>
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime OrderedAt { get; set; }
    }
}