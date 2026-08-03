namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.CreateEmergencyCases
{
    public record CreateEmergencyCasesResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Status { get; set; } = null!;
        public string TriageColor { get; set; } = null!;
        public DateTime ArrivalTime { get; set; }
    }
}