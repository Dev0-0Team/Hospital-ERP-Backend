

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetPatient
{
    public record GetPatientResponse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string? BloodType { get; set; }
    }
}
