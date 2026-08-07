using MediatR;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Queries.GetSurgeriesHistory
{
    public class GetSurgeriesHistoryRequest : IRequest<GetSurgeriesHistoryResponse>
    {
        public int Id {get; set;}
    }
}