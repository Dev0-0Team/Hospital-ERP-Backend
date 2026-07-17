using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Infrastructure.RepoPatients.NewFolder;
using Microsoft.Extensions.DependencyInjection;


namespace Hospital_ERP_Backend.Infrastructure.RepoPatients.Command.Program
{
    public static class CommandPublicProgram
    {
        public static IServiceCollection AddCommandRepositoriesE(this IServiceCollection services)
        {
            services.AddScoped<IBaseCommandRepository<Patient>, PatientsCommandRepository>();
            return services;
        }
    }
}
