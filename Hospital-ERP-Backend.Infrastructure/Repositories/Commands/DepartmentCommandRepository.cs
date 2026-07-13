using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Base;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class DepartmentCommandRepository : BaseCommandRepository<Department>
    {
        public DepartmentCommandRepository(HospitalDbContext dbContext) : base(dbContext) 
        { }
    }
}
