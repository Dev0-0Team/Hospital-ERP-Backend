
namespace Hospital_ERP_Backend.Domain.Interfaces.Base
{
    public interface IBaseCommandRepository<Entity>
    {
        Task<Entity?> CreateAsync(Entity entity);
        Task<Entity?> UpdateAsync(Entity entity);
        Task<bool> DeleteAsync(int id);
    }
}