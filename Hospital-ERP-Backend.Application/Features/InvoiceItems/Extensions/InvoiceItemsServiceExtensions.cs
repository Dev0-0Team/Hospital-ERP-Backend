using FluentValidation;
using Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.CreateInvoiceItem;
using Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.UpdateInvoiceItem;
using Hospital_ERP_Backend.Application.Features.InvoiceItems.Queries.GetAllInvoiceItems;
using Hospital_ERP_Backend.Application.Features.InvoiceItems.Queries.GetInvoiceItem;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.InvoiceItems.Extensions
{
    public static class InvoiceItemsServiceExtensions
    {

        public static IServiceCollection AddInvoiceItemsServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetInvoiceItemRequest>, GetInvoiceItemValidator>();
            services.AddScoped<IValidator<GetAllInvoiceItemsRequest>, GetAllInvoiceItemsValidator>();
            services.AddScoped<IValidator<CreateInvoiceItemRequest>, CreateInvoiceItemValidator>();
            services.AddScoped<IValidator<UpdateInvoiceItemRequest>, UpdateInvoiceItemValidator>();


            services.AddScoped<GetInvoiceItemService>();
            services.AddScoped<GetAllInvoiceItemsService>();
            services.AddScoped<UpdateInvoiceItemService>();
            return services;
        }
    }
}
