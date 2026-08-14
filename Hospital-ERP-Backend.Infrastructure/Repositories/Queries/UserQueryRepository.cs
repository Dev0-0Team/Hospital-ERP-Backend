using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries;

internal class UserQueryRepository : BaseQueryRepository<User>, IUserQuery
{
    protected override string GetAllSpName => "users.SP_GetAllUsers";

    protected override string GetByIdSpName => "users.SP_GetUserById";

    public UserQueryRepository(IOptions<MySetting> setting) : base(setting)
    {
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var parameters = new
        {
            email
        };

        return await _connection.QueryFirstOrDefaultAsync<User>(
            "users.SP_GetUserByEmail",
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> IsEmailExistsAsync(string email)
    {
        var parameters = new
        {
            email
        };

        return await _connection.QuerySingleAsync<bool>(
            "users.SP_IsEmailExists",
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}