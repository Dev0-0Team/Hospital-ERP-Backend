using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Persons.Queries.GetPerson
{
    public record GetPersonRequest : IRequest<GetPersonResponse>
    {
        public int Id { get; set; }
    }
}
