using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Domain.Interfaces
{
    public interface IUserQuery<User> : IBaseQueryRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task<bool> IsEmailExistsAsync(string email);
    }
}
