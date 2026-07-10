using FluentValidation;
using Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.CreateMedicationInventory;
using Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.DeleteMedicationInventory;
using Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.UpdateMedicationInventory;
using Hospital_ERP_Backend.Application.Features.MedicationInventories.Queries.GetAllMedicationInventories;
using Hospital_ERP_Backend.Application.Features.MedicationInventories.Queries.GetMedicationInventory;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Extensions
{
    public static class MedicationInventoryServiceExtensions
    {
        public static IServiceCollection AddMedicationInventoryServicesExtensions(this IServiceCollection services)
        {
            services.AddScoped<IValidator<DeleteMedicationInventoryRequest>, DeleteMedicationInventoryValidator>();
            services.AddScoped<IValidator<CreateMedicationInventoryRequest>, CreateMedicationInventoryValidator>();
            services.AddScoped<IValidator<UpdateMedicationInventoryRequest>, UpdateMedicationInventoryValidator>();
            services.AddScoped<IValidator<GetMedicationInventoryRequest>, GetMedicationInventoryValidator>();
            services.AddScoped<IValidator<GetAllMedicationInventoriesRequest>, GetAllMedicationInventoriesValidator>();


            services.AddScoped<CreateMedicationInventoryService>();
            services.AddScoped<UpdateMedicationInventoryService>();
            services.AddScoped<DeleteMedicationInventoryService>();
            services.AddScoped<GetMedicationInventoryService>();
            services.AddScoped<GetAllMedicationInventoriesService>();


            return services;
        }
    }
}
