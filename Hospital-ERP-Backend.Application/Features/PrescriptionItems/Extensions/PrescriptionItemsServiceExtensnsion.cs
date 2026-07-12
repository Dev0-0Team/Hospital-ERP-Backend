using FluentValidation;
using Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.CreatePrescriptionItem;
using Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.UpdatePrescriptionItem;
using Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetAllPrescriptionItems;
using Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetPrescriptionItem;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Extensions
{
    public static class PrescriptionItemsServiceExtension
    {
        public static IServiceCollection AddPrescriptionItemsServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetPrescriptionItemRequest>, GetPrescriptionItemValidator>();
            services.AddScoped<IValidator<GetAllPrescriptionItemsRequest>, GetAllPrescriptionItemsValidator>();
            services.AddScoped<IValidator<CreatePrescriptionItemRequest>, CreatePrescriptionItemValidator>();
            services.AddScoped<IValidator<UpdatePrescriptionItemRequest>, UpdatePrescriptionItemValidator>();

            services.AddScoped<GetPrescriptionItemService>();
            services.AddScoped<GetAllPrescriptionItemsService>();
            services.AddScoped<CreatePrescriptionItemService>();
            services.AddScoped<UpdatePrescriptionItemService>();
            return services;
        }
    }
}
