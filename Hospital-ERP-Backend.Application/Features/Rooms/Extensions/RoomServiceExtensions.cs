using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetAllRooms;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Extensions
{
    public static class RoomServiceExtensions
    {
        public static IServiceCollection AddRoomServicesExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IValidator<GetAllRoomsRequest>, GetAllRoomsValidator>();

            Services.AddScoped<GetAllRoomsService>();
            return Services;
        }
    }
}