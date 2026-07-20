namespace Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetAllDoctors
{
    public record GetAllDoctorsResponse
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int DepartmentId { get; set; }

        public int SpecializationId { get; set; }

        public string LicenseNumber { get; set; } = string.Empty;
    }
}