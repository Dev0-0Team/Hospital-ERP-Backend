using FluentValidation;
using Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.CreatePaymentMethod;
using Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.DeletePaymentMethod;
using Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod;
using Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetAllPaymentMethods;
using Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetPaymentMethod;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Extensions
{
    public static class PaymentMethodServiceExtensions
    {
        public static IServiceCollection AddPaymentMethodServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreatePaymentMethodRequest>, CreatePaymentMethodValidator>();
            services.AddScoped<IValidator<UpdatePaymentMethodRequest>, UpdatePaymentMethodValidator>();
            services.AddScoped<IValidator<DeletePaymentMethodRequest>, DeletePaymentMethodValidator>();
            services.AddScoped<IValidator<GetPaymentMethodRequest>, GetPaymentMethodValidator>();
            services.AddScoped<IValidator<GetAllPaymentMethodsRequest>, GetAllPaymentMethodsValidator>();

            services.AddScoped<CreatePaymentMethodService>();
            services.AddScoped<UpdatePaymentMethodService>();
            services.AddScoped<DeletePaymentMethodService>();
            services.AddScoped<GetPaymentMethodService>();
            services.AddScoped<GetAllPaymentMethodsService>();
            return services;
        }
    }
}
