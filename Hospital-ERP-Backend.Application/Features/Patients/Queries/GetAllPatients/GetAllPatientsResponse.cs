

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients
{
    public record GetAllPatientsResponse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string? BloodType { get; set; }
    }
}
