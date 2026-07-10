using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class MedicationCommandRepository : IBaseCommandRepository<Medication>
    {
        private readonly HospitalDbContext _dbContext;
        public MedicationCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Medication?> CreateAsync(Medication entity)
        {
            var medication = await _dbContext.Medications.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return medication.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            Medication? medication = await _dbContext.Medications.FindAsync(id);

            if (medication == null)
            {
                return false;
            }

            medication.IsDeleted = true;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Medication?> UpdateAsync(Medication entity)
        {
            Medication? medication = await _dbContext.Medications.FindAsync(entity.Id);

            if (medication == null)
            {
                return null;
            }

            _dbContext.Entry(medication)
                      .CurrentValues
                      .SetValues(entity);

            await _dbContext.SaveChangesAsync();

            return medication;
        }
    }
}
