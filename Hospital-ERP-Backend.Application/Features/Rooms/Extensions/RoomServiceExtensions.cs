using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Rooms.Commands.CreateRoom;
using Hospital_ERP_Backend.Application.Features.Rooms.Commands.UpdateRoom;
using Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetAllRooms;
using Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetRoom;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Extensions
{
    public static class RoomServiceExtensions
    {
        public static IServiceCollection AddRoomServicesExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IValidator<GetAllRoomsRequest>, GetAllRoomsValidator>();
            Services.AddScoped<IValidator<GetRoomRequest>, GetRoomValidator>();
            Services.AddScoped<IValidator<CreateRoomRequest>, CreateRoomValidator>();
            Services.AddScoped<IValidator<UpdateRoomRequest>, UpdateRoomValidator>();

            Services.AddScoped<GetAllRoomsService>();
            Services.AddScoped<GetRoomService>();
            Services.AddScoped<CreateRoomService>();
            Services.AddScoped<UpdateRoomService>();
            return Services;
        }
    }
}