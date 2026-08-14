

using MediatR;
using Microsoft.Identity.Client;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.DeleteSurgeriesHistory
{
    public class DeleteSurgeriesHistoryRequest : IRequest<bool>
    {
        public int Id {get; set;}
    }
}