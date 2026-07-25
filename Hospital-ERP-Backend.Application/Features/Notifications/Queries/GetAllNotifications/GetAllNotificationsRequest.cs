using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetAllNotifications
{
    public record GetAllNotificationsRequest
        : IRequest<IEnumerable<GetAllNotificationsResponse>>
    {
        public int Page { get; set; } = 1;
    }
}