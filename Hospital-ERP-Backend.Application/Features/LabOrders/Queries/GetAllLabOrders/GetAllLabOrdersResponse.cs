namespace Hospital_ERP_Backend.Application.Features.LabOrders.Queries.GetAllLabOrders
{
    public record GetAllLabOrdersResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime OrderedAt { get; set; }
    }
}