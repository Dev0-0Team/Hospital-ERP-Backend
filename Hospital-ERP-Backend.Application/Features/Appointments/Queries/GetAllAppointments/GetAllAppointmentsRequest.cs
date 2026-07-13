using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAllAppointments
{
    public record GetAllAppointmentsRequest : IRequest<IEnumerable<GetAllAppointmentsResponse>>
    {
        public int Page { get; set; }
    }
}