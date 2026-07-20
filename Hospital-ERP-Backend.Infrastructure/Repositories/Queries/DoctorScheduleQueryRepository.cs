using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class DoctorScheduleQueryRepository : BaseQueryRepository<DoctorSchedule>
    {
        protected override string GetByIdSpName => "doctor_schedules.SP_GetDoctorScheduleById";
        protected override string GetAllSpName => "doctor_schedules.SP_GetAllDoctorSchedules";

        public DoctorScheduleQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
