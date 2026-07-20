
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class PatientQueryRepository : BaseQueryRepository<Patient>
    {
        protected override string GetAllSpName => "patients.SP_GetPatientById";
        protected override string GetByIdSpName => "patients.SP_GetAllPatients";

        public PatientQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
