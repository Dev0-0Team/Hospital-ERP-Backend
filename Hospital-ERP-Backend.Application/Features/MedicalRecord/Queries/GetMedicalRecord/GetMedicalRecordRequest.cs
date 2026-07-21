using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Queries.GetMedicalRecord
{
    public record GetMedicalRecordRequest : IRequest<GetMedicalRecordResponse>
    {
        public int Id { get; set; }
    }
}