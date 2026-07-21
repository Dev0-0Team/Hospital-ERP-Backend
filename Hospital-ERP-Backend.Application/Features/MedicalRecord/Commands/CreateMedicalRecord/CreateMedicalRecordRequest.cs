using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.CreateMedicalRecord
{
    public record CreateMedicalRecordRequest : IRequest<CreateMedicalRecordResponse>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Diagnosis { get; set; } = null!;
        public string? Notes { get; set; }
        public DateTime VisitDate { get; set; }
    }
}