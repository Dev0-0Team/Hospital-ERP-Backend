

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.DeletePatient
{
    public record DeletePatientRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
