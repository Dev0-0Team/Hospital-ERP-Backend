
namespace Hospital_ERP_Backend.Domain.Interfaces.Base
{
    public interface IBaseCommandRepository<Entity, DTOCreate, DTOUpdate>
    {
        Task<Entity> CreateAsync(DTOCreate entity);
        Task<Entity> UpdateAsync(DTOUpdate entity);
        Task<bool> DeleteAsync(int id);
    }
}