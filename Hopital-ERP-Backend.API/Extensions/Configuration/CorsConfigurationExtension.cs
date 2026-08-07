namespace Hospital_ERP_Backend.API.Extensions.Configuration;

public static class CorsConfigurationExtension
{
    public static IServiceCollection AddCorsConfigurationExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("DevelopmentPolicy", policy =>
            {
                // Allow requests from any origin in development, but you can restrict this in production or after Mohmmed is done with the front-end
                policy
                    .WithOrigins()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }
}