namespace Hospital_ERP_Backend.Application.Features.RadiologyOrders.Queries.GetAllRadiologyOrders
{
    public record GetAllRadiologyOrdersResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Type { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime OrderedAt { get; set; }
    }
}