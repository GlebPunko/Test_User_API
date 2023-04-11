using Infastructure.Context;
using Infastructure.Repositories;
using Infastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infastructure.DI
{
    public static class InfastructureDI
    {
        public static IServiceCollection AddInfastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>((DbContextOptionsBuilder options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLConnection"));
            });

            services.AddScoped<IUserControlRepository, UserControlRepository>();

            return services;
        }
    }
}
