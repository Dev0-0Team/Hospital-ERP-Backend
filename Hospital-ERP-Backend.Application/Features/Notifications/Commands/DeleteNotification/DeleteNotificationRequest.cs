using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Commands.DeleteNotification
{
    public record DeleteNotificationRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}