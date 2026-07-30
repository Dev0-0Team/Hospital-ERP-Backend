using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class AllergyQueryRepository : BaseQueryRepository<Allergy>
    {
        protected override string GetAllSpName => "allergies.SP_GetAllAllergies";
        protected override string GetByIdSpName => "allergies.SP_GetAllergyById";

        public AllergyQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
