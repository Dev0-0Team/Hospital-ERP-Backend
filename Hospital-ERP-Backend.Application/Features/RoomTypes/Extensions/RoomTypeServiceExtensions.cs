using FluentValidation;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.CreateRoomType;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.DeleteRoomType;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.UpdateRoomType;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetAllRoomTypes;
using Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetRoomType;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Extensions
{
    public static class RoomTypeServiceExtensions
    {
        public static IServiceCollection AddRoomTypeServicesExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IValidator<GetAllRoomTypesRequest>, GetAllRoomTypesValidator>();
            Services.AddScoped<IValidator<GetRoomTypeRequest>, GetRoomTypeValidator>();
            Services.AddScoped<IValidator<CreateRoomTypeRequest>, CreateRoomTypeValidator>();
            Services.AddScoped<IValidator<UpdateRoomTypeRequest>, UpdateRoomTypeValidator>();
            Services.AddScoped<IValidator<DeleteRoomTypeRequest>, DeleteRoomTypeValidator>();

            Services.AddScoped<GetAllRoomTypesService>();
            Services.AddScoped<GetRoomTypeService>();
            Services.AddScoped<CreateRoomTypeService>();
            Services.AddScoped<UpdateRoomTypeService>();
            Services.AddScoped<DeleteRoomTypeService>();
            return Services;
        }
    }
}