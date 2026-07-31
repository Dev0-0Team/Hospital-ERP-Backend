using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class QueuePriorityQueryRepository : BaseQueryRepository<QueuePriority>
    {
        protected override string GetAllSpName => "queue_priorities.SP_GetAllQueuePriorities";
        protected override string GetByIdSpName => "queue_priorities.SP_GetQueuePriorityById";

        public QueuePriorityQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}