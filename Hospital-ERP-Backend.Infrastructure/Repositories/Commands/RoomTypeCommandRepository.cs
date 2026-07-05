using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class RoomTypeCommandRepository : IBaseCommandRepository<RoomType>
    {
        private readonly HospitalDbContext _dbContext;

        public RoomTypeCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<RoomType?> CreateAsync(RoomType entity)
        {
            RoomType roomType = entity;

            await _dbContext.RoomTypes.AddAsync(roomType);
            await _dbContext.SaveChangesAsync();
            return roomType;
        }

        public async Task<RoomType?> UpdateAsync(RoomType entity)
        {
            RoomType? roomType = await _dbContext.RoomTypes.FindAsync(entity.Id);
            if (roomType == null)
            {
                return null;
            }

            _dbContext.Entry(roomType).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return roomType;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            RoomType? roomType = await _dbContext.RoomTypes.FindAsync(id);
          
            if (roomType == null)
            {
                return false;
            }
            _dbContext.Remove(roomType);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
