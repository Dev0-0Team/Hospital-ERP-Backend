namespace Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetAllNotifications
{
    public record GetAllNotificationsResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;

        public bool IsRead { get; set; }
    }
}