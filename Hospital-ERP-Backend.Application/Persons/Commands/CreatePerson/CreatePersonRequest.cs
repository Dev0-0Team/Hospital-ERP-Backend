

namespace Hospital_ERP_Backend.Application.Persons.Commands.CreatePerson
{
    public record CreatePersonRequest
    {
        public string FullName { get; set; } = null!;
        public DateOnly Dob { get; set; }
        public string Gender { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
    }
}
