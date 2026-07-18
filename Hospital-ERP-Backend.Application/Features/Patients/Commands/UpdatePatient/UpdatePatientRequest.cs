using Hospital_ERP_Backend.Application.Features.Persons.Commands.UpdatePerson;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.UpdatePatient
{
    public record UpdatePatientRequest : IRequest<UpdatePatientResponse>
    {
        public int PersonId { get; set; }

        public string? BloodType { get; set; }

    }
}
