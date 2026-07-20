using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetPatient
{
    public record GetPatientRequest : IRequest<GetPatientResponse>
    {
        public int Id { get; set; }
    }
}
