using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.CreateDrugInteraction
{
    public record CreateDrugInteractionRequest : IRequest<CreateDrugInteractionResponse>
    {
        public int Medication1Id { get; set; }

        public int Medication2Id { get; set; }

        public string Severity { get; set; } = string.Empty;

        public string Warning { get; set; } = string.Empty;
    }
}