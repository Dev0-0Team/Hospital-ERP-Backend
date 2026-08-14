using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Domain.Interfaces
{
    public interface IUserQuery : IBaseQueryRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task<bool> IsEmailExistsAsync(string email);
    }
}
