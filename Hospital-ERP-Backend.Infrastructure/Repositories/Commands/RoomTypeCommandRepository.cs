using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Base;
using Microsoft.EntityFrameworkCore;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class RoomTypeCommandRepository : BaseCommandRepository<RoomType>
    {
        public RoomTypeCommandRepository(HospitalDbContext dbContext) : base(dbContext) { }

    }
}


