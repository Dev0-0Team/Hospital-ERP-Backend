using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class ChronicDiseaseQueryRepository : BaseQueryRepository<ChronicDisease>
    {
        protected override string GetAllSpName => "chronic_diseases.SP_GetAllChronicDiseases";
        protected override string GetByIdSpName => "chronic_diseases.SP_GetChronicDiseaseById";
        public ChronicDiseaseQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
