

using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class RoleCommandRepository : IBaseCommandRepository<Role>
    {
        private readonly HospitalDbContext _dbContext;

        public RoleCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role?> CreateAsync(Role entity)
        {
            Role role = entity;

            await _dbContext.AddAsync(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role?> UpdateAsync(Role entity)
        {
            Role? role = await _dbContext.Roles.FindAsync(entity.Id);
            if (role == null)
                return null;

            _dbContext.Entry(role).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null)
            {
                return false;
            }

            _dbContext.Remove(role);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
