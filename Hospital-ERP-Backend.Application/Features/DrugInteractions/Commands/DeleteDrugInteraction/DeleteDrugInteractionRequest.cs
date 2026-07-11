using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.DeleteDrugInteraction
{
    public record DeleteDrugInteractionRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}