using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class UserQueryRepository : BaseQueryRepository<User>
    {
        protected override string GetAllSpName => "users.SP_GetAllUsers";
        protected override string GetByIdSpName => "users.SP_GetUserById";

        public UserQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}
