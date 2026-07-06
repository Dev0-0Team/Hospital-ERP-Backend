using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.DeletePerson
{
    public record DeletePersonRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
