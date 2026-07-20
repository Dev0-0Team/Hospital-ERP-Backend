using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.DeleteDoctor
{
    public record DeleteDoctorRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}