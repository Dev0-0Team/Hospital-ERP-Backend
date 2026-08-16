

using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Domain.Interfaces.Permission
{
    public interface IPermissionQueryRepository : IBaseQueryRepository<Hospital_ERP_Backend.Domain.Entities.Permission> 
    {
        Task<IEnumerable<Hospital_ERP_Backend.Domain.Entities.Permission>> GetUserPermissionBitValuesAsync(int userId);

    }
}