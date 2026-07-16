using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetAllNurses
{
    public record GetAllNursesRequest : IRequest<IEnumerable<GetAllNursesResponse>>
    {
        public int Page { get; set; }
    }
}
