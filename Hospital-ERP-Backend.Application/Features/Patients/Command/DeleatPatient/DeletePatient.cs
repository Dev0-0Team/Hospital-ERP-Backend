using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Patients.Command.DeletePatient
{
    public record DeletePatient : IRequest<bool>
    {
        public int PersonId { get; set; }

        

    }
}
