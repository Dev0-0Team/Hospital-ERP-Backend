using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class RefreshTokenQueryRepository : BaseQueryRepository<RefreshToken>, IRefreshTokenQueryRepository
    {
        protected override string GetAllSpName => "refresh_tokens.SP_GetAllRefreshTokens ";
        protected override string GetByIdSpName => "refresh_tokens.SP_GetRefreshTokenById";

        public RefreshTokenQueryRepository(IOptions<MySetting> options, HospitalDbContext context) : base(options)
        {

        }

        public async Task<IEnumerable<RefreshToken>> GetActiveTokensByUserIdAsync(int userId)
        {
            var parameters = new
            {
                UserId = userId
            };

            return await _connection.QueryAsync<RefreshToken>("[authorization].SP_GetActiveRefreshTokensByUserId",
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
