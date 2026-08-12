using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.CreateDrugInteraction;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.CreateEmergencyCases;
using Hospital_ERP_Backend.Domain.Entities;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.CreateEmergencyCases;

public record CreateEmergencyCasesRequest : IRequest<CreateEmergencyCasesResponse>
{

    public int PatientId { get; set; }
    public string Status { get; set; } = string.Empty;

    public string TriageColor { get; set; } = string.Empty;

    public DateTime ArrivalTime { get; set; }

   // public Patient Patient { get; set; } = null!;
}