namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.UpdatePrescription
{
    public record UpdatePrescriptionResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }
    }
}