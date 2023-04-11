using Application.Services;
using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infastructure.DI
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserControlService, UserControlService>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
