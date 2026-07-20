using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetAllDoctorSchedules
{
    public record GetAllDoctorSchedulesRequest
        : IRequest<IEnumerable<GetAllDoctorSchedulesResponse>>
    {
        public int Page { get; set; }
    }
}