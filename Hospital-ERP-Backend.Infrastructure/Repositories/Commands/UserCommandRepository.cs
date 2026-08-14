using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Base;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    internal class UserCommandRepository : BaseCommandRepository<User>, IUserCommand
    {
        private readonly HospitalDbContext _context;

        public UserCommandRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
