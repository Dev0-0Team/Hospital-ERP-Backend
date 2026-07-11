using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class LabTestQueryRepository : BaseQueryRepository<LabTest>
    {
        protected override string GetAllSpName => "lab_tests.SP_GetAllLabTests";
        protected override string GetByIdSpName => "lab_tests.SP_GetLabTestById";

        public LabTestQueryRepository(IOptions<MySetting> mySetting) : base(mySetting) { }
    }
}
