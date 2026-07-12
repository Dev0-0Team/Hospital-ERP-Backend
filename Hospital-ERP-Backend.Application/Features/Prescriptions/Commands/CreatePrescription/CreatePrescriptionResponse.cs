namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.CreatePrescription
{
    public record CreatePrescriptionResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }
    }
}