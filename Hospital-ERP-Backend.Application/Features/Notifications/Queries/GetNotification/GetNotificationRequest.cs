using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetNotification
{
    public record GetNotificationRequest : IRequest<GetNotificationResponse>
    {
        public int Id { get; set; }
    }
}