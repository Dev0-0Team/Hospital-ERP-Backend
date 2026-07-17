using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Patients.Command.UpdatePatient
{
    public record UpdatePatient : IRequest<UpdatePatientCommand>
    {
        public int PersonId { get; set; }

        public string? BloodType { get; set; }

    }
}
