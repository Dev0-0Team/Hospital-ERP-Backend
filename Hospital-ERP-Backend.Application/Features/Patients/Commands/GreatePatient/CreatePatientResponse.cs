

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.GreatePatient
{
    public record CreatePatientResponse
    {
        public int PersonId { get; set; }

        public string? BloodType { get; set; }
    }
}
