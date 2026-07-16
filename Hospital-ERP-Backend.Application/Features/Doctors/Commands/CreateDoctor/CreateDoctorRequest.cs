using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.CreateDoctor
{
    public record CreateDoctorRequest : IRequest<CreateDoctorResponse>
    {
        public int PersonId { get; set; }

        public int DepartmentId { get; set; }

        public int SpecializationId { get; set; }

        public string LicenseNumber { get; set; } = string.Empty;
    }
}