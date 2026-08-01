using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class AppointmentQueueQueryRepository : BaseQueryRepository<AppointmentQueue>
    {
        protected override string GetAllSpName => "appointment_queues.SP_GetAllAppointmentQueues";
        protected override string GetByIdSpName => "appointment_queues.SP_GetAppointmentQueueById";

        public AppointmentQueueQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}