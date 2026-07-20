namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Queries.GetAllEmergencyContacts
{
    public record GetAllEmergencyContactsResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Relationship { get; set; } = null!;
    }
}