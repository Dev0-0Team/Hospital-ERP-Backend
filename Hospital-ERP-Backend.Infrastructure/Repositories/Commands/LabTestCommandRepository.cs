using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class LabTestCommandRepository : IBaseCommandRepository<LabTest>
    {
        private readonly HospitalDbContext _dbContext;
        public LabTestCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LabTest?> CreateAsync(LabTest entity)
        {
            var labTest = await _dbContext.LabTests.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return labTest.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            LabTest? labTest = await _dbContext.LabTests.FindAsync(id);
            if (labTest == null) return false;

            labTest.IsDeleted = true;
            labTest.DeletedAt = DateTime.UtcNow;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<LabTest?> UpdateAsync(LabTest entity)
        {
            LabTest? labTest = await _dbContext.LabTests.FindAsync(entity.Id);
            if (labTest == null) return null;

            _dbContext.Entry(labTest).CurrentValues.SetValues(entity);

            labTest.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
            return labTest;
        }
    }
}
}
