using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class RadiologyReportQueryRepository : BaseQueryRepository<RadiologyReport>
    {
        protected override string GetAllSpName => "radiology_reports.SP_GetAllRadiologyReports";
        protected override string GetByIdSpName => "radiology_reports.SP_GetRadiologyReportById";

        public RadiologyReportQueryRepository(IOptions<MySetting> options) : base(options) { }

    }
}
