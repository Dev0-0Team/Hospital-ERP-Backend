using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class MedicationQueryRepository : BaseQueryRepository<Medication>
    {
        protected override string GetAllSpName => "medications.SP_GetAllMedications";
        protected override string GetByIdSpName => "medications.SP_GetMedicationById";
        public MedicationQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}