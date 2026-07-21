using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class MedicalRecordQueryRepository : BaseQueryRepository<MedicalRecord>
    {
        protected override string GetAllSpName => "medical_records.SP_GetAllMedicalRecords";
        protected override string GetByIdSpName => "medical_records.SP_GetMedicalRecordById";

        public MedicalRecordQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}