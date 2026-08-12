
namespace Hospital_ERP_Backend.Domain.Interfaces.Base
{
    public interface IBaseQueryRepository<Entity>
    {
        Task<IEnumerable<Entity>> GetAllAsync(int page);
        Task<Entity?> GetAsync(int ID);

    }
}
