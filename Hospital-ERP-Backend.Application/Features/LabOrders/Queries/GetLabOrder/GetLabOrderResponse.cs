namespace Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetLabOrder
{
    public record GetLabOrderResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime OrderedAt { get; set; }
    }
}