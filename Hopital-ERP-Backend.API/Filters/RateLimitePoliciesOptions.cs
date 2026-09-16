

namespace Hospital_ERP_Backend.API.Filters
{
    public record RateLimitePoliciesOptions
    {
        public NameRateLimitPolicies PolicyName { get; set; } = NameRateLimitPolicies.AuthLimiter;
        public int PermitLimit { get; set; }
        public int WindowMinutes { get; set; }
        public int QueueLimit { get; set; } = 0;

    }
}