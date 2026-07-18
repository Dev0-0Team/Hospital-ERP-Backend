using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Base;
using System;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Commands
{
    public class PatientsCommandRepository : BaseCommandRepository<Patient>
    {
        public PatientsCommandRepository(HospitalDbContext dbContext) : base(dbContext) { }

    }
}
