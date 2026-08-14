using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.UpdateEmergencyCases
{
    public record UpdateEmergencyCasesRequest : IRequest<UpdateEmergencyCasesResponse>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string TriageColor { get; set; } = string.Empty;
        public DateTime ArrivalTime { get; set; }
    }
}
