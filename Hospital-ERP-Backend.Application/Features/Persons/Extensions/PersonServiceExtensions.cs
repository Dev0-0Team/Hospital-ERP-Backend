using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Persons.Commands.CreatePerson;
using Hospital_ERP_Backend.Application.Features.Persons.Commands.DeletePerson;
using Hospital_ERP_Backend.Application.Features.Persons.Commands.UpdatePerson;
using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetAllPersons;
using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetPerson;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_ERP_Backend.Application.Features.Persons.Extensions
{
    public static class PersonServiceExtensions
    {
        public static IServiceCollection AddPersonServicesExtension(this IServiceCollection Services)
        {
            Services.AddScoped<IValidator<CreatePersonRequest>, CreatePersonValidator>();
            Services.AddScoped<IValidator<UpdatePersonRequest>, UpdatePersonValidator>();
            Services.AddScoped<IValidator<DeletePersonRequest>, DeletePersonValidator>();
            Services.AddScoped<IValidator<GetPersonRequest>, GetPersonValidator>();
            Services.AddScoped<IValidator<GetAllPersonsRequest>, GetAllPersonsValidator>();

            Services.AddScoped<CreatePersonService>();
            Services.AddScoped<UpdatePersonService>();
            Services.AddScoped<DeletePersonService>();
            Services.AddScoped<GetPersonService>();
            Services.AddScoped<GetAllPersonsService>();
            return Services;
        }
    }
}
