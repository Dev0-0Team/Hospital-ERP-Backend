namespace Hospital_ERP_Backend.Application.Features.LabOrders.Commands.CreateLabOrder
{
    public record CreateLabOrderResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime OrderedAt { get; set; }
    }
}