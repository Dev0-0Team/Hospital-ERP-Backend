using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class EmergencyCasesQueryRepository : BaseQueryRepository<EmergencyCase>
    {
        protected override string GetAllSpName => "EmergencyCases.SP_GetAllEmergencyCases";

        protected override string GetByIdSpName => "SP_GetEmergencyCaseById";

       public EmergencyCasesQueryRepository(IOptions<MySetting> settings) : base(settings) { }
    }
}
