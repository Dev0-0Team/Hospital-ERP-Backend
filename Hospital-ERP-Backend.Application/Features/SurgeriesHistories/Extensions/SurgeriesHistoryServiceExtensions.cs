using FluentValidation;
using Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.CreateSurgeriesHistory;
using Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.DeleteSurgeriesHistory;
using Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.UpdateSurgeriesHistory;
using Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Queries.GetAllSurgeriesHistories;
using Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Queries.GetSurgeriesHistory;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Extensions
{
    public static class SurgeriesHistoryServiceExtensions
    {
        public static IServiceCollection AddSurgeriesHistoryServicesExtension(this IServiceCollection service)
        {
            service.AddScoped<IValidator<GetAllSurgeriesHistoriesRequest>, GetAllSurgeriesHistoriesValidator>();
            service.AddScoped<IValidator<GetSurgeriesHistoryRequest>, GetSurgeriesHistoryValidator>();
            service.AddScoped<IValidator<UpdateSurgeriesHistoryRequest>, UpdateSurgeriesHistoryValidator>();
            service.AddScoped<IValidator<DeleteSurgeriesHistoryRequest>, DeleteSurgeriesHistoryValidator>();
            service.AddScoped<IValidator<CreateSurgeriesHistoryRequest>, CreateSurgeriesHistoryValidator>();

            service.AddScoped<GetAllSurgeriesHistoriesService>();
            service.AddScoped<GetSurgeriesHistoryService>();
            service.AddScoped<UpdateSurgeriesHistoryService>();
            service.AddScoped<DeleteSurgeriesHistoryService>();
            service.AddScoped<CreateSurgeriesHistoryService>();
            
            return service;
        }
    }
}