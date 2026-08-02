using Hospital_ERP_Backend.Domain.Enums;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.UpdatePatient
{
    public record UpdatePatientRequest : IRequest<UpdatePatientResponse>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public PatientBloodType? BloodType { get; set; }
    }
}
