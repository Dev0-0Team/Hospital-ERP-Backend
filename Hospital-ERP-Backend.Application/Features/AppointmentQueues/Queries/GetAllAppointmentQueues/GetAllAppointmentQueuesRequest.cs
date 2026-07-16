using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Queries.GetAllAppointmentQueues
{
    public record GetAllAppointmentQueuesRequest : IRequest<IEnumerable<GetAllAppointmentQueuesResponse>>
    {
        public int Page { get; set; }
    }
}