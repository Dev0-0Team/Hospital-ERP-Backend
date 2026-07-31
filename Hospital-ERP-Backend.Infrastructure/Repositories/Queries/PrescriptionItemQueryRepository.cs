using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class PrescriptionItemQueryRepository : BaseQueryRepository<PrescriptionItem>
    {
        protected override string GetAllSpName => "prescription_items.SP_GetAllPrescriptionItems";
        protected override string GetByIdSpName => "prescription_items.SP_GetPrescriptionItemById";

        public PrescriptionItemQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
