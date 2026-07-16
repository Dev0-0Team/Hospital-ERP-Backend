using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class SpecializationQueryRepository : BaseQueryRepository<Specialization>
    {
        protected override string GetAllSpName => "specializations.SP_GetAllSpecializations";
        protected override string GetByIdSpName => "specializations.SP_GetSpecializationsById";

        public SpecializationQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
