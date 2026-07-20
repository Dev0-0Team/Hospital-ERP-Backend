using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients
{
    public record GetAllPatientsRequest : IRequest<IEnumerable<GetAllPatientsResponse>>
    {
        public int Page {  get; set; }
    }
}
