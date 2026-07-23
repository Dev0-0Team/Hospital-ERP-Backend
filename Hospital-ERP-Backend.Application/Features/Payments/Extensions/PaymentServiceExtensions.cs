using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Payments.Commands.CreatePayment;
using Hospital_ERP_Backend.Application.Features.Payments.Commands.DeletePayment;
using Hospital_ERP_Backend.Application.Features.Payments.Commands.UpdatePayment;
using Hospital_ERP_Backend.Application.Features.Payments.Queries.GetAllPayments;
using Hospital_ERP_Backend.Application.Features.Payments.Queries.GetPayment;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Payments.Extensions
{
    public static class PaymentServiceExtensions
    {
        public static IServiceCollection AddPaymentMethodServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreatePaymentRequest>, CreatePaymentValidator>();
            services.AddScoped<IValidator<UpdatePaymentRequest>, UpdatePaymentValidator>();
            services.AddScoped<IValidator<DeletePaymentRequest>, DeletePaymentValidator>();
            services.AddScoped<IValidator<GetPaymentRequest>, GetPaymentValidator>();
            services.AddScoped<IValidator<GetAllPaymentsRequest>, GetAllPaymentsValidator>();

            services.AddScoped<CreatePaymentService>();
            services.AddScoped<UpdatePaymentService>();
            services.AddScoped<DeletePaymentService>();
            services.AddScoped<GetPaymentService>();
            services.AddScoped<GetAllPaymentsService>();
            return services;
        }
    }
}
