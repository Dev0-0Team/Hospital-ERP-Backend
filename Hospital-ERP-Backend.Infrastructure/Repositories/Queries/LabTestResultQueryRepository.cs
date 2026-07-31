using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class LabTestResultQueryRepository : BaseQueryRepository<LabTestResult>
    {
        protected override string GetAllSpName => "lab_test_results.SP_GetAllLabTestResults";
        protected override string GetByIdSpName => "lab_test_results.SP_GetLabTestResultById";

        public LabTestResultQueryRepository(IOptions<MySetting> options) : base(options){ }
    }
}
