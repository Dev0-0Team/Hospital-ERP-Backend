using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetAllPersons;
using MediatR;
using System.Collections;

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients
{
    public record GetAllPatientRequest : IRequest<IEnumerable<GetAllPateintResponse>>
    {
        public int PersonId { get; set; }
    }
}
