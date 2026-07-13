

using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class DepartmentQueryRepository : BaseQueryRepository<Department>
    {
        protected override string GetAllSpName => "departments.SP_GetAllDeparments";
        protected override string GetByIdSpName => "departments.SP_GetDeparmentById";

        public DepartmentQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
