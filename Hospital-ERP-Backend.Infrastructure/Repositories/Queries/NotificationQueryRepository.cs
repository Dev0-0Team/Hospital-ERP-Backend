using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class NotificationQueryRepository : BaseQueryRepository<Notification>
    {
        protected override string GetAllSpName => "notifications.SP_GetAllNotifications";
        protected override string GetByIdSpName => "notifications.SP_GetNotificationById";

        public NotificationQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}
