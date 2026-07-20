using FluentValidation;
using Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.CreateRoomAssignment;
using Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.DeleteRoomAssignment;
using Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.UpdateRoomAssignment;
using Hospital_ERP_Backend.Application.Features.RoomAssignments.Queries.GetAllRoomAssignments;
using Hospital_ERP_Backend.Application.Features.RoomAssignments.Queries.GetRoomAssignment;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Extensions
{
    public static class RoomAssignmentServiceExtensions
    {
        public static IServiceCollection AddRoomAssignmentServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllRoomAssignmentsRequest>, GetAllRoomAssignmentsValidator>();
            services.AddScoped<IValidator<GetRoomAssignmentRequest>, GetRoomAssignmentValidator>();
            services.AddScoped<IValidator<CreateRoomAssignmentRequest>, CreateRoomAssignmentValidator>();
            services.AddScoped<IValidator<UpdateRoomAssignmentRequest>, UpdateRoomAssignmentValidator>();
            services.AddScoped<IValidator<DeleteRoomAssignmentRequest>, DeleteRoomAssignmentValidator>();

            services.AddScoped<GetAllRoomAssignmentsService>();
            services.AddScoped<GetRoomAssignmentService>();
            services.AddScoped<CreateRoomAssignmentService>();
            services.AddScoped<UpdateRoomAssignmentService>();
            services.AddScoped<DeleteRoomAssignmentService>();
            return services;
        }
    }
}