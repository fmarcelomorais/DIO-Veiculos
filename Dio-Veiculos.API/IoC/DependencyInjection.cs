using Dio_Veiculos.API.Application.Interfaces;
using Dio_Veiculos.API.Application.Services;
using Dio_Veiculos.API.Domain.Interfaces;
using Dio_Veiculos.API.Infraestructure.Context;
using Dio_Veiculos.API.Infraestructure.Repositories;

namespace Dio_Veiculos.API.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>();
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            services.AddScoped<IAdministratorService, AdministratorService>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoService, VeiculoService>();

            return services;
        }
    }
}
