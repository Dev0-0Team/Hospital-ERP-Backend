using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Infrastructure.RepoPatients.NewFolder
{
    public class PatientsCommandRepository : BaseCommandRepository<Patient>
    {
        public PatientsCommandRepository(HospitalDbContext dbContext) : base(dbContext) { }

    }
}
