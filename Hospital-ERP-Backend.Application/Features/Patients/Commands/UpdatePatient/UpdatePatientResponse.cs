

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.UpdatePatient
{
    public record UpdatePatientResponse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string? BloodType { get; set; }
    }
}
