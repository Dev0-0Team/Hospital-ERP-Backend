using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;
using System.Data;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class UserQueryRepository : BaseQueryRepository<User>
    {
        protected override string GetAllSpName => "users.SP_GetAllUsers";
        protected override string GetByIdSpName => "users.SP_GetUserById";

        public async Task<User?> GetUserByEmailAsync(string email)
        {

            return await _connection.QueryFirstOrDefaultAsync<User>("users.SP_GetUserByEmail",
                new { email = email },
                commandType: CommandType.StoredProcedure);
        }

        public UserQueryRepository(IOptions<MySetting> setting) : base(setting) { }

    }
}
