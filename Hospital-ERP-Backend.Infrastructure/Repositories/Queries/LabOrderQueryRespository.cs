using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class LabOrderQueryRespository : BaseQueryRepository<LabOrder>
    {
        protected override string GetAllSpName => "lab_orders.SP_GetAllLabOrders";
        protected override string GetByIdSpName => "lab_orders.SP_GetLabOrderById";

        public LabOrderQueryRespository(IOptions<MySetting> setting) : base(setting) { }
    }
}
