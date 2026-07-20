using FluentValidation;
using Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.CreateEmergencyContact;
using Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.DeleteEmergencyContact;
using Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.UpdateEmergencyContact;
using Hospital_ERP_Backend.Application.Features.EmergencyContacts.Queries.GetAllEmergencyContacts;
using Hospital_ERP_Backend.Application.Features.EmergencyContacts.Queries.GetEmergencyContact;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Extensions
{
    public static class EmergencyContactsServiceExtensions
    {
        public static IServiceCollection AddEmergencyContactsServicesExtension(this IServiceCollection services)
        {

            services.AddScoped<IValidator<GetAllEmergencyContactsRequest>, GetAllEmergencyContactsValidator>();
            services.AddScoped<IValidator<GetEmergencyContactRequest>, GetEmergencyContactValidator>();
            services.AddScoped<IValidator<CreateEmergencyContactRequest>, CreateEmergencyContactValidator>();
            services.AddScoped<IValidator<UpdateEmergencyContactRequest>, UpdateEmergencyContactValidator>();
            services.AddScoped<IValidator<DeleteEmergencyContactRequest>, DeleteEmergencyContactValidator>();

            services.AddScoped<GetAllEmergencyContactsService>();
            services.AddScoped<GetEmergencyContactService>();
            services.AddScoped<CreateEmergencyContactService>();
            services.AddScoped<UpdateEmergencyContactService>();
            services.AddScoped<DeleteEmergencyContactService>();
            return services;
        }
    }
}