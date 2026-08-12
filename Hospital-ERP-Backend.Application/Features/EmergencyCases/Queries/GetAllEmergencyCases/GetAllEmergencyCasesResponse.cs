namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Queries.GetAllEmergencyCases
{
    public record GetAllEmergencyCasesResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Status { get; set; } = null!;
        public string TriageColor { get; set; } = null!;
        public DateTime ArrivalTime { get; set; }
    }
}
