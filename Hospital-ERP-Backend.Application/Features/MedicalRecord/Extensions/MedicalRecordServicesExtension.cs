using FluentValidation;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.CreateMedicalRecord;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.DeleteMedicalRecord;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Commands.UpdateMedicalRecord;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Queries.GetAllMedicalRecords;
using Hospital_ERP_Backend.Application.Features.MedicalRecords.Queries.GetMedicalRecord;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.MedicalRecords.Extensions
{
    public static class MedicalRecordServicesExtension
    {
        public static IServiceCollection AddMedicalRecordServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetMedicalRecordRequest>, GetMedicalRecordValidator>();
            services.AddScoped<IValidator<GetAllMedicalRecordsRequest>, GetAllMedicalRecordsValidator>();
            services.AddScoped<IValidator<CreateMedicalRecordRequest>, CreateMedicalRecordValidator>();
            services.AddScoped<IValidator<UpdateMedicalRecordRequest>, UpdateMedicalRecordValidator>();
            services.AddScoped<IValidator<DeleteMedicalRecordRequest>, DeleteMedicalRecordValidator>();

            services.AddScoped<GetAllMedicalRecordsService>();
            services.AddScoped<GetMedicalRecordService>();
            services.AddScoped<UpdateMedicalRecordService>();
            services.AddScoped<DeleteMedicalRecordService>();
            services.AddScoped<CreateMedicalRecordService>();

            return services;
        }
    }
}