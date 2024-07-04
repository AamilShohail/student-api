using Database.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database
{
    public static partial class StartupExtensions
    {
        public static IServiceCollection AddStudentDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentDbContext>(configuration, "StudentDbConnection");

            services.AddScoped<IDbAccessProvider, DbAccessProvider>();

            return services;
        }
    }
}
