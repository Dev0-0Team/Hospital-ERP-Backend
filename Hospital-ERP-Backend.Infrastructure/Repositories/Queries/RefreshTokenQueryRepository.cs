using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Data;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class RefreshTokenQueryRepository : BaseQueryRepository<RefreshToken>, IRefreshTokenQueryRepository
    {
        private readonly HospitalDbContext _context;

        protected override string GetAllSpName => "refresh_tokens.SP_GetAllRefreshTokens ";
        protected override string GetByIdSpName => "refresh_tokens.SP_GetRefreshTokenById";

        public RefreshTokenQueryRepository(IOptions<MySetting> options, HospitalDbContext context) : base(options)
        {
            _context = context;
        }

        public async Task<RefreshToken?> GetByHashAsync(string hash)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.TokenHash == hash);
        }
    }
}
