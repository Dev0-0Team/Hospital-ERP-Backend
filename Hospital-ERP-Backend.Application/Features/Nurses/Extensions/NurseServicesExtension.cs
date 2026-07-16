

using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Nurses.Commands.CreateNurse;
using Hospital_ERP_Backend.Application.Features.Nurses.Commands.DeleteNurse;
using Hospital_ERP_Backend.Application.Features.Nurses.Commands.UpdateNurse;
using Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetAllNurses;
using Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetNurse;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Extensions
{
    public static class NurseServicesExtension
    {
        public static IServiceCollection AddNurseServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetNurseRequest>, GetNurseValidator>();
            services.AddScoped<IValidator<GetAllNursesRequest>, GetAllNursesValidator>();
            services.AddScoped<IValidator<CreateNurseRequest>, CreateNurseValidator>();
            services.AddScoped<IValidator<UpdateNurseRequest>, UpdateNurseValidator>();
            services.AddScoped<IValidator<DeleteNurseRequest>, DeleteNurseValidator>();

            services.AddScoped<GetAllNursesService>();
            services.AddScoped<GetNurseService>();
            services.AddScoped<UpdateNurseService>();
            services.AddScoped<DeleteNurseService>();
            services.AddScoped<CreateNurseService>();
            return services;
        }
    }
}
