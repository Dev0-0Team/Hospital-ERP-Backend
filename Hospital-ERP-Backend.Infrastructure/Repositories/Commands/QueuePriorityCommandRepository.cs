using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Base;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    internal class QueuePriorityCommandRepository : BaseCommandRepository<QueuePriority>
    {
        public QueuePriorityCommandRepository(HospitalDbContext dbContext) : base(dbContext) { }

    }
}