using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class MedicationQueryRepository : BaseQueryRepository<Medication>
    {
        protected override string GetAllSpName => "medication.SP_GetAllMedications";
        protected override string GetByIdSpName => "medication.SP_GetMedicationById";
        public MedicationQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}