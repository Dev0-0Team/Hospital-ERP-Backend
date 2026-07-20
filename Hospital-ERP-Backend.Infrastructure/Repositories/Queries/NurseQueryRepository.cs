using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class NurseQueryRepository : BaseQueryRepository<Nurse>
    {
        protected override string GetAllSpName => "nurses.SP_GetAllNurses";
        protected override string GetByIdSpName => "nurses.SP_GetNurseById";

        public NurseQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
