
using FluentValidation;
using Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.CreateAdministrativeStaff;
using Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.DeleteAdministrativeStaff;
using Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.UpdateAdministrativeStaff;
using Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAdministrativeStaff;
using Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAllAdministrativeStaffs;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Extensions
{
    public static class AdministrativeStaffServiceExtensions
    {
        public static IServiceCollection AddAdministrativeStaffServicesExtension(this IServiceCollection service)
        {
            service.AddScoped<IValidator<GetAllAdministrativeStaffsRequest>, GetAllAdministrativeStaffsValidator>();
            service.AddScoped<IValidator<GetAdministrativeStaffRequest>, GetAdministrativeStaffValidator>();
            service.AddScoped<IValidator<CreateAdministrativeStaffRequest>, CreateAdministrativeStaffValidator>();
            service.AddScoped<IValidator<UpdateAdministrativeStaffRequest>, UpdateAdministrativeStaffValidator>();
            service.AddScoped<IValidator<DeleteAdministrativeStaffRequest>, DeleteAdministrativeStaffValidator>();

            service.AddScoped<GetAllAdministrativeStaffsService>();
            service.AddScoped<GetAdministrativeStaffService>();
            service.AddScoped<CreateAdministrativeStaffService>();
            service.AddScoped<UpdateAdministrativeStaffService>();
            service.AddScoped<DeleteAdministrativeStaffService>();

            return service;
        }
    }
}