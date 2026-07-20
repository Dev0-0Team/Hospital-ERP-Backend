using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Base;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class AppointmentQueueCommandRepository : BaseCommandRepository<AppointmentQueue>
    {
        public AppointmentQueueCommandRepository(HospitalDbContext dbContext) : base(dbContext) { }
    }
}