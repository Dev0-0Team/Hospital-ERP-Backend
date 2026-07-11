using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetAllDrugInteractions
{
    public record GetAllDrugInteractionsRequest : IRequest<IEnumerable<GetAllDrugInteractionsResponse>>
    {
        public int Page { get; set; }
    }
}