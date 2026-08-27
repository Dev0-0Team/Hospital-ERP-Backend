using Hospital_ERP_Backend.Domain.Entities;

public interface IRefreshTokenQueryRepository
{
    Task<IEnumerable<RefreshToken>> GetActiveTokensByUserIdAsync(int userId);
}