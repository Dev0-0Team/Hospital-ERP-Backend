namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetPrescription
{
    public record GetPrescriptionResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }
    }
}