using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Commands.Base;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class PersonQueryRepository : BaseQueryRepository<Person>
    {
        protected override string GetAllSpName => "persons.SP_GetAllPersons";
        protected override string GetByIdSpName => "persons.SP_GetPersonById";

        public PersonQueryRepository(IOptions<MySetting> setting): base(setting)
        { }
    }
}
