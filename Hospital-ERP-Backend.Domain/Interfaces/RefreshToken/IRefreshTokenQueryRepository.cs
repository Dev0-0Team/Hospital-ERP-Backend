using Hospital_ERP_Backend.Domain.Entities;

public interface IRefreshTokenQueryRepository
{
    Task<RefreshToken?> GetByHashAsync(string hash);
}