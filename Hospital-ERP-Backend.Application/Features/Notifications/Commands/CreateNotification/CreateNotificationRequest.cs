using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Notifications.Commands.CreateNotification
{
    public record CreateNotificationRequest
        : IRequest<CreateNotificationResponse>
    {
        public int UserId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;

        public bool IsRead { get; set; }
    }
}