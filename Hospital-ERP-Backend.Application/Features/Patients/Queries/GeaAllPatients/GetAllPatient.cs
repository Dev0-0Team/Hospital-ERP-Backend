using MediatR;
using System.Collections;

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients
{
    public record GetAllPatient : IRequest<IEnumerable<GetAllPatientQuery>>
    {
        public int PersonId { get; set; }
    }
}
