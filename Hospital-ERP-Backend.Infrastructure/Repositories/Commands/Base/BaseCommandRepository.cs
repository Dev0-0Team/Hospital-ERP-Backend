using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Base
{
    public class BaseCommandRepository<T> : IBaseCommandRepository<T> where T : BaseEntity
    {

        protected readonly HospitalDbContext _dbContext;
        protected BaseCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public virtual async Task<T?> CreateAsync(T entity)
        {
            T newEntity = entity;

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return newEntity;
        }

        public virtual async Task<T?> UpdateAsync(T entity)
        {
            T? updatedEntity = await _dbContext.Set<T>().FindAsync(entity.Id);
            if (updatedEntity == null)
            {
                return null;
            }

            _dbContext.Entry(updatedEntity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();

            return updatedEntity;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            T? deleteEntity = await _dbContext.Set<T>().FindAsync(id);
            if (deleteEntity == null)
            {
                return false;
            }
            deleteEntity.IsDeleted = true;
            deleteEntity.DeletedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
