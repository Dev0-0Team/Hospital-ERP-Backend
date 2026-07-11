
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class PermissionCommandRepository : IBaseCommandRepository<Permission> 
    {

        public PermissionCommandRepository(HospitalDbContext dbContext) : base(dbContext) { }

    }
}
