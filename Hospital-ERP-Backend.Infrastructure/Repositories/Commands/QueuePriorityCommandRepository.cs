using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class QueuePriorityCommandRepository : IBaseCommandRepository<QueuePriority>
    {
        private readonly HospitalDbContext _dbContext;
        public QueuePriorityCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<QueuePriority?> CreateAsync(QueuePriority entity)
        {
            var queuePriority = await _dbContext.QueuePriorities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return queuePriority.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            QueuePriority? queuePriority = await _dbContext.QueuePriorities.FindAsync(id);
            if (queuePriority == null) return false;

            queuePriority.IsDeleted = true;
            queuePriority.DeletedAt = DateTime.UtcNow;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<QueuePriority?> UpdateAsync(QueuePriority entity)
        {
            QueuePriority? queuePriority = await _dbContext.QueuePriorities.FindAsync(entity.Id);
            if (queuePriority == null) return null;

            _dbContext.Entry(queuePriority).CurrentValues.SetValues(entity);

            await _dbContext.SaveChangesAsync();
            return queuePriority;
        }
    }
}