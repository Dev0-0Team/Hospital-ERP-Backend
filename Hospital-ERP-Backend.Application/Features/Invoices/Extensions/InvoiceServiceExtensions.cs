using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Invoices.Commands.CreateInvoice;
using Hospital_ERP_Backend.Application.Features.Invoices.Commands.DeleteInvoice;
using Hospital_ERP_Backend.Application.Features.Invoices.Commands.UpdateInvoice;
using Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetAllInvoices;
using Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetInvoice;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Invoices.Extensions
{
    public static class InvoiceServiceExtensions
    {
        public static IServiceCollection AddInvoiceServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateInvoiceRequest>, CreateInvoiceValidator>();
            services.AddScoped<IValidator<UpdateInvoiceRequest>, UpdateInvoiceValidator>();
            services.AddScoped<IValidator<DeleteInvoiceRequest>, DeleteInvoiceValidator>();
            services.AddScoped<IValidator<GetInvoiceRequest>, GetInvoiceValidator>();
            services.AddScoped<IValidator<GetAllInvoicesRequest>, GetAllInvoicesValidator>();

            services.AddScoped<CreateInvoiceService>();
            services.AddScoped<UpdateInvoiceService>();
            services.AddScoped<DeleteInvoiceService>();
            services.AddScoped<GetInvoiceService>();
            services.AddScoped<GetAllInvoicesService>();

            return services;
        }
    }
}