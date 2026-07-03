

using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class RolePermissionCommandRepository : IBaseCommandRepository<RolePermission>
    {
        private readonly HospitalDbContext _dbContext;
        public RolePermissionCommandRepository(HospitalDbContext context)
        {
            _dbContext = context;
        }

        public async Task<RolePermission?> CreateAsync(RolePermission entity)
        {
            RolePermission rolePermission = entity;
            await _dbContext.RolePermissions.AddAsync(rolePermission);
            await _dbContext.SaveChangesAsync();
            return rolePermission;
        }
        public async Task<RolePermission?> UpdateAsync(RolePermission entity)
        {
            RolePermission? rolePermission = await _dbContext.RolePermissions.FindAsync(entity.Id);
            if (rolePermission == null)
            {
                return null;
            }

            // Update the role permission entity with the new values
            _dbContext.Entry(rolePermission).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return rolePermission;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            RolePermission? entity = await _dbContext.RolePermissions.FindAsync(id);
            if (entity == null) return false;

            _dbContext.RolePermissions.Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
