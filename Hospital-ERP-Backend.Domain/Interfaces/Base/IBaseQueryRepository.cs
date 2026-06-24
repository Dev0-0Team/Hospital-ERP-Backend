
namespace Hospital_ERP_Backend.Domain.Interfaces.Base
{
    public interface IBaseQueryRepository<Entity>
    {
        Task<List<Entity>> GetAllDataAsync(int page);
        Task<Entity?> GetDataAsync(int ID);
    }
}
