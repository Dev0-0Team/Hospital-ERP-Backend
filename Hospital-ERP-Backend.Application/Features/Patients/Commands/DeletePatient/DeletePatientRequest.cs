using Hospital_ERP_Backend.Application.Features.Persons.Commands.DeletePerson;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.DeletePatient
{
    public record DeletePatientRequest : IRequest<bool>
    {
        public int PersonId { get; set; }

        

    }
}