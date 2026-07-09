using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class MedicationInventoryCommandRepository : IBaseCommandRepository<MedicationInventory>
    {
        private readonly HospitalDbContext _dbContext;

        public MedicationInventoryCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MedicationInventory?> CreateAsync(MedicationInventory entity)
        {
            var medicationInventory =
                await _dbContext.MedicationInventories.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return medicationInventory.Entity;
        }

        public async Task<MedicationInventory?> UpdateAsync(MedicationInventory entity)
        {
            MedicationInventory? medicationInventory =
                await _dbContext.MedicationInventories.FindAsync(entity.Id);

            if (medicationInventory == null)
            {
                return null;
            }

            _dbContext.Entry(medicationInventory)
                      .CurrentValues
                      .SetValues(entity);

            medicationInventory.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            return medicationInventory;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            MedicationInventory? medicationInventory =
                await _dbContext.MedicationInventories.FindAsync(id);

            if (medicationInventory == null)
            {
                return false;
            }

            medicationInventory.IsDeleted = true;
            medicationInventory.DeletedAt = DateTime.UtcNow;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}