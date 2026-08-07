using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class SurgeriesHistoryQueryRepository : BaseQueryRepository<SurgeriesHistory>
    {
        protected override string GetAllSpName => "[surgercies_histories].[SP_GetAllSurgeriesHistories]";
        protected override string GetByIdSpName => "[surgercies_histories].[SP_GetSurgeriesHistoryById]";

        public SurgeriesHistoryQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}