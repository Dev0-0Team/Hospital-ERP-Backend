using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class AllergyQueryRepository : BaseQueryRepository<Allergy>
    {
        protected override string GetAllSpName => "dbo.SP_Allergy_GetAll";
        protected override string GetByIdSpName => "dbo.SP_Allergy_GetById";

        public AllergyQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}