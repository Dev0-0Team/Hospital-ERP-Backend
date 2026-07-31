using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class BedQueryRepository : BaseQueryRepository<Bed>
    {
        protected override string GetAllSpName => "beds.SP_GetAllBeds";
        protected override string GetByIdSpName => "beds.SP_GetBedById";

        public BedQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}