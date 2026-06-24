using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.People.Commands
{
    public class PersonCommandRepository : IBaseCommandRepository<Person>
    {
        private readonly HospitalDbContext _dbContext;

        public PersonCommandRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Person?> CreateAsync(Person entity)
        {
            Person person = entity;

            await _dbContext.AddAsync(person);
            await _dbContext.SaveChangesAsync();

            return person;
        }

        public async Task<Person?> UpdateAsync(Person entity)
        {
            Person? person = await _dbContext.Persons.FindAsync(entity.Id);
            if (person == null)
            {
                return null;
            }

            // Update the person entity with the new values
            _dbContext.Entry(person).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();

            return person;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Person? person = await _dbContext.Persons.FindAsync(id);
            if (person == null)
            {
                return false;
            }

            _dbContext.Persons.Remove(person);

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
