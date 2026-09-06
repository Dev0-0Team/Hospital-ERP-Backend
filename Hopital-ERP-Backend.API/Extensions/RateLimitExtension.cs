using System.Threading.RateLimiting;
using Hospital_ERP_Backend.API.Exceptions;
using Hospital_ERP_Backend.API.Filters;
using Microsoft.AspNetCore.RateLimiting;

namespace Hospital_ERP_Backend.API.Extensions
{
    public static class RateLimitExtension
    {
        private static void AddPolicy(
            RateLimiterOptions options,
            RateLimitePoliciesOptions policyOptions,
            Func<HttpContext, string> partitionKeyFactory)
        {
            options.AddPolicy(
                policyOptions.PolicyName.ToString(),
                httpContext =>
                {
                    var partitionKey = partitionKeyFactory(httpContext);

                    return RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey,
                        _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = policyOptions.PermitLimit,
                            Window = TimeSpan.FromMinutes(policyOptions.WindowMinutes),
                            QueueLimit = policyOptions.QueueLimit,
                            AutoReplenishment = true
                        });
                });
        }

        public static IServiceCollection AddRateLimitingExtension(
            this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode =
                    StatusCodes.Status429TooManyRequests;

                // Login - IP based
                AddPolicy(
                    options,
                    new RateLimitePoliciesOptions
                    {
                        PolicyName = NameRateLimitPolicies.AuthLimiter,
                        PermitLimit = 5,
                        WindowMinutes = 1
                    },
                    httpContext =>
                        httpContext.Connection.RemoteIpAddress?.ToString()
                        ?? "unknown");


                // GET ALL - User ID based
                AddPolicy(
                    options,
                    new RateLimitePoliciesOptions
                    {
                        PolicyName = NameRateLimitPolicies.GetAllLimiter,
                        PermitLimit = 120,
                        WindowMinutes = 1
                    },
                    GetUserId);


                // GET ONE - User ID based
                AddPolicy(
                    options,
                    new RateLimitePoliciesOptions
                    {
                        PolicyName = NameRateLimitPolicies.GetOneLimiter,
                        PermitLimit = 180,
                        WindowMinutes = 1
                    },
                    GetUserId);


                // ADD - User ID based
                AddPolicy(
                    options,
                    new RateLimitePoliciesOptions
                    {
                        PolicyName = NameRateLimitPolicies.AddLimiter,
                        PermitLimit = 30,
                        WindowMinutes = 1
                    },
                    GetUserId);


                // UPDATE - User ID based
                AddPolicy(
                    options,
                    new RateLimitePoliciesOptions
                    {
                        PolicyName = NameRateLimitPolicies.UpdateLimiter,
                        PermitLimit = 30,
                        WindowMinutes = 1
                    },
                    GetUserId);


                // DELETE - User ID based
                AddPolicy(
                    options,
                    new RateLimitePoliciesOptions
                    {
                        PolicyName = NameRateLimitPolicies.DeleteLimiter,
                        PermitLimit = 15,
                        WindowMinutes = 1
                    },
                    GetUserId);
            });

            return services;
        }

        private static string GetUserId(HttpContext context)
        {
            return context.User.FindFirst("userID")?.Value
                   ?? "anonymous";
        }

        public static WebApplication UseRateLimitingExtension(this WebApplication app)
        {
            app.UseRateLimiter();
            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == StatusCodes.Status429TooManyRequests)
                {
                    throw new TooManyRequestsException("Too many requests. Please try again later.");
                }
            });
            return app;
        }
    }
}