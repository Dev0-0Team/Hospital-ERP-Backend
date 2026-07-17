using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient
{
    public record GetIDPatient : IRequest<GetIDPatientQuery>
    {
        public int PersonId { get; set; }
    }
}
