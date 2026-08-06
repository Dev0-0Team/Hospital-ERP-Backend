using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class PersonQueryRepository : BaseQueryRepository<Person>
    {
        protected override string GetAllSpName => "persons.SP_GetAllPersons";
        protected override string GetByIdSpName => "persons.SP_GetPersonById";

        public PersonQueryRepository(IOptions<MySetting> setting): base(setting)
        { }
    }
}
