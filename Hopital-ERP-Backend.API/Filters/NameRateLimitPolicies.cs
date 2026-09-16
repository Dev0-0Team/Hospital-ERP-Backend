
namespace Hospital_ERP_Backend.API.Filters
{
    public enum NameRateLimitPolicies
    {
        AuthLimiter = 1,
        GetAllLimiter,
        GetOneLimiter,
        AddLimiter,
        UpdateLimiter,
        DeleteLimiter
    }
}