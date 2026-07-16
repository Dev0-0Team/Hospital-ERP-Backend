using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetDoctor
{
    public record GetDoctorRequest : IRequest<GetDoctorResponse>
    {
        public int Id { get; set; }
    }
}