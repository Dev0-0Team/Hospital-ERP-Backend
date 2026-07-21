namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.UpdateMedicalRecord
{
    public record UpdateMedicalRecordResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Diagnosis { get; set; } = null!;
        public string? Notes { get; set; }
        public DateTime VisitDate { get; set; }
    }
}