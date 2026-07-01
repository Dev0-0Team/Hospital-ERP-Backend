

using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class UserRoleCommandRepository : IBaseCommandRepository<UserRole>
    {
        private readonly HospitalDbContext _dbContext;
        public UserRoleCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserRole?> CreateAsync(UserRole entity)
        {
            UserRole userRole = entity;
            await _dbContext.AddAsync(userRole);
            await _dbContext.SaveChangesAsync();
            return userRole;
        }

        public async Task<UserRole?> UpdateAsync(UserRole entity)
        {
            UserRole? userRole = await _dbContext.UserRoles.FindAsync(entity.Id);
            if (userRole == null)
            {
                return null;
            }

            // Update the user role entity with the new values
            _dbContext.Entry(userRole).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return userRole;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            UserRole? userRole = await _dbContext.UserRoles.FindAsync(id);
            if (userRole == null)
            {
                return false;
            }

            _dbContext.UserRoles.Remove(userRole);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
