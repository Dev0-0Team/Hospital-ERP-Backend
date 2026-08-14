using Hospital_ERP_Backend.Domain.Entities;

namespace Hospital_ERP_Backend.Domain.Interfaces
{
    public interface IUserCommand
    {
        Task AddAsync(User user);
    }
}
