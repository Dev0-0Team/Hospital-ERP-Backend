namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetAllPrescriptions
{
    public record GetAllPrescriptionsResponse
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }
    }
}