using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class AppointmentQueryRepository : BaseQueryRepository<Appointment>
    {
        protected override string GetAllSpName => "appointments.SP_GetAllAppointments";
        protected override string GetByIdSpName => "appointments.SP_GetAppointmentById";

        public AppointmentQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}