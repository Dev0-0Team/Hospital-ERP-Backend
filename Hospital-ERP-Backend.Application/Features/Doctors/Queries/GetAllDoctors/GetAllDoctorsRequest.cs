using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetAllDoctors
{
    public record GetAllDoctorsRequest : IRequest<IEnumerable<GetAllDoctorsResponse>>
    {
        public int Page { get; set; }
    }
}