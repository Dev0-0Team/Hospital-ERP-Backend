using FluentValidation;
using Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.CreateChronicDisease;
using Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetAllChronicDiseases;
using Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetChronicDisease;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Extensions
{
    public static class ChronicDiseaseServiceExtensions
    {
        public static IServiceCollection AddChronicDiseaseServicesExtension(this IServiceCollection services)
        {

            services.AddScoped<IValidator<GetAllChronicDiseasesRequest>, GetAllChronicDiseasesValidator>();
            services.AddScoped<IValidator<GetChronicDiseaseRequest>, GetChronicDiseaseValidator>();
            services.AddScoped<IValidator<CreateChronicDiseaseRequest>, CreateChronicDiseaseValidator>();

            services.AddScoped<GetAllChronicDiseasesService>();
            services.AddScoped<GetChronicDiseaseService>();
            services.AddScoped<CreateChronicDiseaseService>();
            return services;
        }
    }
}
