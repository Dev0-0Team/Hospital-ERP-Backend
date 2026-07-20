using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class EmergencyContactQueryRepository : BaseQueryRepository<EmergencyContact>
    {
        protected override string GetAllSpName => "emergency_contacts.SP_GetAllEmergencyContacts";
        protected override string GetByIdSpName => "emergency_contacts.SP_GetEmergencyContactById";

        public EmergencyContactQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}