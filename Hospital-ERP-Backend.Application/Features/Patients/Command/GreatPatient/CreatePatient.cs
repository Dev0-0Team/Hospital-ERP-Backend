using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Patients.Command.GreatPatient
{
    public record CreatePatient : IRequest<GreatPatientCommand>
    {
        public int PersonId { get; set; }

        public string? BloodType { get; set; }

    }
}
