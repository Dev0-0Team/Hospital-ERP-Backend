using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetDrugInteraction
{
    public class GetDrugInteractionRequest : IRequest<GetDrugInteractionResponse>
    {
        public int Id { get; set; }
    }
}
