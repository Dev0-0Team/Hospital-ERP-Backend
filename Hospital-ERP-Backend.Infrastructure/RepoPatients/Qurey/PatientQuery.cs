using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class PatientQuery : BaseQueryRepository<Patient>
    {
        protected override string GetAllSpName => "dbo.SP_Patients_GetAll";
        protected override string GetByIdSpName => "dbo.SP_Patients_GetById";

        public PatientQuery(IOptions<MySetting> setting) : base(setting) { }

    }
}
