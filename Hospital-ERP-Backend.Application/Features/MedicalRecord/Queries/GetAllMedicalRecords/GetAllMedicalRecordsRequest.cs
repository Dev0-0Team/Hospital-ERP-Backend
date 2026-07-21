using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Queries.GetAllMedicalRecords
{
    public record GetAllMedicalRecordsRequest : IRequest<IEnumerable<GetAllMedicalRecordsResponse>>
    {
        public int Page { get; set; }
    }
}