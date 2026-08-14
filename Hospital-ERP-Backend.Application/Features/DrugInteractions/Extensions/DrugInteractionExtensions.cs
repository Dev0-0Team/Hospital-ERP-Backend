using FluentValidation;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.CreateDrugInteraction;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.DeleteDrugInteraction;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.UpdateDrugInteraction;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetAllDrugInteractions;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetDrugInteraction;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.DrugInteractions.Extensions
{
    public static class DrugInteractionExtensions
    {
        public static IServiceCollection AddDrugInteractionsServicesExtension(this IServiceCollection services)
        {

            services.AddScoped<IValidator<DeleteDrugInteractionRequest>, DeleteDrugInteractionValidator>();
            services.AddScoped<IValidator<GetDrugInteractionRequest>, GetDrugInteractionValidator>();
            services.AddScoped<IValidator<GetAllDrugInteractionsRequest>, GetAllDrugInteractionsValidator>();
            services.AddScoped<IValidator<UpdateDrugInteractionRequest>, UpdateDrugInteractionValidator>();
            services.AddScoped<IValidator<CreateDrugInteractionRequest>, CreateDrugInteractionValidator>();

            services.AddScoped<DeleteDrugInteractionService>();
            services.AddScoped<GetDrugInteractionService>();
            services.AddScoped<GetAllDrugInteractionsService>();
            services.AddScoped<UpdateDrugInteractionService>();
            services.AddScoped<CreateDrugInteractionService>();

            return services;

        }
    }
}
