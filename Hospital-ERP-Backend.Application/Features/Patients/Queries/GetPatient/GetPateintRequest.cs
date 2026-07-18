using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient;
using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetPerson;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient
{
    public record GetPateintRequest : IRequest<GetPateintResponse>
    {
        public int PersonId { get; set; }
    }
}
