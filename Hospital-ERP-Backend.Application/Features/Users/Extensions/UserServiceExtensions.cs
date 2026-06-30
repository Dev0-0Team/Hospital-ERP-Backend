using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Persons.Commands.CreatePerson;
using Hospital_ERP_Backend.Application.Features.Persons.Commands.DeletePerson;
using Hospital_ERP_Backend.Application.Features.Persons.Commands.UpdatePerson;
using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetAllPersons;
using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetPerson;
using Hospital_ERP_Backend.Application.Features.Users.Commands.CreateUser;
using Hospital_ERP_Backend.Application.Features.Users.Commands.DeleteUser;
using Hospital_ERP_Backend.Application.Features.Users.Commands.UpdateUser;
using Hospital_ERP_Backend.Application.Features.Users.Queries.GetAllUsers;
using Hospital_ERP_Backend.Application.Features.Users.Queries.GetUser;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Hospital_ERP_Backend.Application.Features.Users.Extensions
{
    public static class UserServiceExtensions
    {
        public static IServiceCollection AddUserServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateUserRequest>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserRequest>, UpdateUserValidator>();
            services.AddScoped<IValidator<DeleteUserRequest>, DeleteUserValidator>();
            services.AddScoped<IValidator<GetUserRequest>, GetUserValidator>();
            services.AddScoped<IValidator<GetAllUsersRequest>, GetAllUsersValidator>();
            
            services.AddScoped<CreateUserService>();
            services.AddScoped<UpdateUserService>();
            services.AddScoped<DeleteUserService>();
            services.AddScoped<GetUserService>();
            services.AddScoped<GetAllUsersService>();
            return services;
        }
    }
}
