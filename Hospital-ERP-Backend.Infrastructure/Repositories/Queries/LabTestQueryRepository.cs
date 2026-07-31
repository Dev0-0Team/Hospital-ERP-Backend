using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;
namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class LabTestQueryRepository : BaseQueryRepository<LabTest>
    {
        protected override string GetAllSpName => "lab_tests.SP_GetAllLabTests";
        protected override string GetByIdSpName => "lab_tests.SP_GetLabTestById";

        public LabTestQueryRepository(IOptions<MySetting> mySetting) : base(mySetting) { }
    }
}
