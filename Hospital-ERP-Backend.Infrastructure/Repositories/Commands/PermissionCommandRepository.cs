
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Base;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    internal class PermissionCommandRepository : BaseCommandRepository<Permission> 
    {
        public PermissionCommandRepository(HospitalDbContext dbContext) : base(dbContext) { }
    }
}
