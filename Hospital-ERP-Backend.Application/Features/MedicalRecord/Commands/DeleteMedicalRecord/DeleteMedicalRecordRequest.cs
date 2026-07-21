using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.DeleteMedicalRecord
{
    public record DeleteMedicalRecordRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}