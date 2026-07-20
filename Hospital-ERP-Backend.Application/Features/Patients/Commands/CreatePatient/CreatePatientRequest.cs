

using MediatR;
using Microsoft.Identity.Client;

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.CreatePatient
{
    public record CreatePatientRequest : IRequest<CreatePatientResponse>
    {
        public int PersonId { get; set; }
        public string? BloodType { get; set; }
    }
}
