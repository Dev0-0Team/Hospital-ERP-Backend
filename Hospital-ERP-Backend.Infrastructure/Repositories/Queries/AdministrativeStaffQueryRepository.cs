using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class AdministrativeStaffQueryRepository : BaseQueryRepository<AdministrativeStaff>
    {
        protected override string GetAllSpName => "administrative_staff.SP_GetAllAdministativeStaff";
        protected override string GetByIdSpName => "administrative_staff.SP_GetAdministrativeStaffById";

        public AdministrativeStaffQueryRepository(IOptions<MySetting> setting) : base(setting) {}
    }
}