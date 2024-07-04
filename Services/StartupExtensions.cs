using Microsoft.Extensions.DependencyInjection;
using Services.StudentServices;

namespace Services
{
    public static class StartupExtensions
    {
        public static IServiceCollection RegisterServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentManager, StudentManager>();

            return services;
        }
    }
}
