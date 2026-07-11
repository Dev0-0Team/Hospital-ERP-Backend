using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class QueuePriorityQueryRepository : BaseQueryRepository<QueuePriority>
    {
        protected override string GetAllSpName => "queue_priorities.SP_GetAllQueuePriorities";
        protected override string GetByIdSpName => "queue_priorities.SP_GetQueuePriorityById";

        public QueuePriorityQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}