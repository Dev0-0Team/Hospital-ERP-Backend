using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class PrescriptionQueryRepository : BaseQueryRepository<Prescription>
    {
        protected override string GetAllSpName => "prescriptions.SP_GetAllPrescriptions";
        protected override string GetByIdSpName => "prescriptions.SP_GetPrescriptionById";

        public PrescriptionQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
