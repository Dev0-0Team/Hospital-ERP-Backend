

using Hospital_ERP_Backend.Domain.Enums;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.CreatePatient
{
    public record CreatePatientRequest : IRequest<CreatePatientResponse>
    {
        public int PersonId { get; set; }
        public PatientBloodType? BloodType { get; set; }
    }
}
