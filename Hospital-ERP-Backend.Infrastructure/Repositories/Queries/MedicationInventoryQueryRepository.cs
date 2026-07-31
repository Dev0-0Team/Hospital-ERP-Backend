using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class MedicationInventoryQueryRepository : BaseQueryRepository<MedicationInventory>
    {
        protected override string GetAllSpName => "medication_inventories.SP_GetAllMedicationInventories";
        protected override string GetByIdSpName => "medication_inventories.SP_GetMedicationInventoryById";

        public MedicationInventoryQueryRepository( IOptions<MySetting> setting) : base(setting) { }

    }
}