using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Persons.Commands.CreatePerson
{
    public record CreatePersonRequest : IRequest<CreatePersonResponse>
    {
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Gender { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
    }
}
