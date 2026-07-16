using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class DoctorQueryRepository : BaseQueryRepository<Doctor>
    {
        protected override string GetAllSpName => "doctors.SP_GetAllDoctors";
        protected override string GetByIdSpName => "doctors.SP_GetDoctorById";

        public DoctorQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}
