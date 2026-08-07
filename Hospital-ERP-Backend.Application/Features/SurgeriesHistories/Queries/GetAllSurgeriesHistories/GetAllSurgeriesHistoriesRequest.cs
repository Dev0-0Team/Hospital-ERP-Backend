using MediatR;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Queries.GetAllSurgeriesHistories
{
    public class GetAllSurgeriesHistoriesRequest : IRequest<IEnumerable<GetAllSurgeriesHistoriesResponse>>
    {
        public int Page {get; set;}
    }
}