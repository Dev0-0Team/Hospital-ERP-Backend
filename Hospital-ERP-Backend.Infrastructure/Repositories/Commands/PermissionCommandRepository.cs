
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class PermissionCommandRepository : IBaseCommandRepository<Permission> 
    {
        private readonly HospitalDbContext _dbContext;
        
        public PermissionCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Permission?> CreateAsync(Permission entity)
        {
            Permission permission = entity;

            await _dbContext.Permissions.AddAsync(permission);
            await _dbContext.SaveChangesAsync();
            return permission;
        }

        public async Task<Permission?> UpdateAsync(Permission entity)
        {
            Permission? permission = await _dbContext.Permissions.FindAsync(entity.Id);
            if (permission == null)
                return null;

            _dbContext.Entry(permission).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return permission;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Permission? permission = await _dbContext.Permissions.FindAsync(id);
            if (permission == null)
            {
                return false;
            }

            permission.IsDeleted = true;
            permission.DeletedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
