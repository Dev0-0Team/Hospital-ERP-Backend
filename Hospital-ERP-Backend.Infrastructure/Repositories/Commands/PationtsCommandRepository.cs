

using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class PatientCommandRepository : IBaseCommandRepository<Patient>
    {
        private readonly HospitalDbContext _dbContext;
        public PatientCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Patient?> CreateAsync(Patient entity)
        {
            Patient patient= entity;
            await _dbContext.Patients.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
            return patient;
        }
        public async Task<Patient?> UpdateAsync(Patient entity)
        {
            Patient? patient = await _dbContext.Patients.FindAsync(entity.Id);
            if (patient == null)
            {
                return null;
            }s
            // Update the user entity with the new values
            _dbContext.Entry(patient).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return patient;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            Patient patient = await _dbContext.Patients.FindAsync(id);
            if (patient == null)
            {
                return false;
            }
            _dbContext.Patients.Remove(patient);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
