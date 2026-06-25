
namespace Hospital_ERP_Backend.Application.Persons.Queries.GetAllPersons
{
    public record GetAllPersonsResponse
    {
        public int Id { get; set; } 
        public string FullName { get; set; } = null!;

        public DateTime Dob { get; set; }

        public string Gender { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string? Address { get; set; }
    }
}
