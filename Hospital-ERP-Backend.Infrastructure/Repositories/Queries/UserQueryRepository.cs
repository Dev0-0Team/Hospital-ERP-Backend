using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class UserQueryRepository : BaseQueryRepository<User>
    {
        protected override string GetAllSpName => "users.SP_GetAllUsers";
        protected override string GetByIdSpName => "users.SP_GetUserById";
        protected override string GetUserByEmailSpName => "users.SP_GetUserByEmail";
        protected override string IsEmailExistsSpName => "users.SP_IsEmailExists";


        public UserQueryRepository(IOptions<MySetting> setting) : base(setting)
        {


        }
    }
}



