using System.Data;
using Dapper;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Permission;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class PermissionQueryRepository : BaseQueryRepository<Permission>, IPermissionQueryRepository
    {
        protected override string GetAllSpName => "permissions.SP_GetAllPermissions";
        protected override string GetByIdSpName => "permissions.SP_GetPermissionById";
        private string GetUserPermissionByUserID => "[authorization].SP_GetUserPermissionBitValues";
        public PermissionQueryRepository(IOptions<MySetting> setting) : base(setting) { }


        public async Task<IEnumerable<Permission>> GetUserPermissionBitValuesAsync(int userId)
        {
            var parameters = new
            {
                userId            };
            return await _connection.QueryAsync<Permission>(
                GetUserPermissionByUserID,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
