using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class MedicationInventoryQueryRepository : BaseQueryRepository<MedicationInventory>
    {
        protected override string GetAllSpName => "medication_inventories.SP_GetAllMedicationInventories";
        protected override string GetByIdSpName => "medication_inventories.SP_GetMedicationInventoryById";

        public MedicationInventoryQueryRepository( IOptions<MySetting> setting) : base(setting) { }

    }
}