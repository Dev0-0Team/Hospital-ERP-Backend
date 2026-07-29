using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Base;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    internal class AdministrativeStaffCommandRepository: BaseCommandRepository<AdministrativeStaff>
    {
        public AdministrativeStaffCommandRepository(HospitalDbContext dbContext) : base(dbContext){}
    }
}