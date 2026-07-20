namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.CreateDoctor
{
    public record CreateDoctorResponse
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int DepartmentId { get; set; }

        public int SpecializationId { get; set; }

        public string LicenseNumber { get; set; } = string.Empty;
    }
}