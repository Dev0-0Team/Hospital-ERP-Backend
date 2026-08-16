using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Domain.Interfaces.User
{
    public interface IUserQueryRepository : IBaseQueryRepository<Hospital_ERP_Backend.Domain.Entities.User>
    {
        Task<Hospital_ERP_Backend.Domain.Entities.User?> GetUserByEmailAsync(string email);

        Task<bool> IsEmailExistsAsync(string email);
    }
}
