using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetNurse
{
    public record GetNurseRequest : IRequest<GetNurseResponse>
    {
        public int Id { get; set; }
    }
}
