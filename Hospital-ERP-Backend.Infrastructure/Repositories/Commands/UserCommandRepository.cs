

using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class UserCommandRepository : IBaseCommandRepository<User>
    {
        private readonly HospitalDbContext _dbContext;
        public UserCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User?> CreateAsync(User entity)
        {
            User user = entity;
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<User?> UpdateAsync(User entity)
        {
            User? user = await _dbContext.Users.FindAsync(entity.Id);
            if (user == null)
            {
                return null;
            }
            // Update the user entity with the new values
            _dbContext.Entry(user).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            User? user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            user.Status = "Deleted";
            user.IsDeleted = true;
            user.DeletedAt = DateTime.Now;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
