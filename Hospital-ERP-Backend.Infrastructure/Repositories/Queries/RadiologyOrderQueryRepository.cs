using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class RadiologyOrderQueryRepository : BaseQueryRepository<RadiologyOrder>
    {
        protected override string GetAllSpName => "radiology_orders.SP_GetAllRadiologyOrders";
        protected override string GetByIdSpName => "radiology_orders.SP_GetRadiologyOrderById";

        public RadiologyOrderQueryRepository(IOptions<MySetting> setting) : base(setting)
        {
        }

    }
}
