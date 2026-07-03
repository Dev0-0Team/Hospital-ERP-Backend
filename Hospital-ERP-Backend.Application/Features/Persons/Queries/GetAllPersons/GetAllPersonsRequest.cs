using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Persons.Queries.GetAllPersons
{
    public record GetAllPersonsRequest : IRequest<IEnumerable<GetAllPersonsResponse>>
    {
        public int page {  get; set; }
    }
}
