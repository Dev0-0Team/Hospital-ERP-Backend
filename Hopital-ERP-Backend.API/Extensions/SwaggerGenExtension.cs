using Microsoft.OpenApi.Models;
using Hospital_ERP_Backend.API.Filters;

namespace Hospital_ERP_Backend.API.Extensions
{
    public static class SwaggerGenExtension
    {
        public static IServiceCollection AddSwaggerGenExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter: Bearer {your JWT token}"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                    },
                    new string[] {}
                    }
                });
                options.OperationFilter<DefaultResponsesOperationFilter>();
            });

            return services;
        }
    }
}
