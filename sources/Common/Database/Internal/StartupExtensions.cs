using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    static partial class StartupExtensions
    {
        private static IServiceCollection AddDbContext<TContext>(this IServiceCollection services, IConfiguration configuration, string connectionStringName) where TContext : IdentityDbContext
        {
            services.AddDbContext<TContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(connectionStringName), options => options.EnableRetryOnFailure())
            );

            services.AddIdentity<Student, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
              .AddEntityFrameworkStores<TContext>()
              .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;

                options.SignIn.RequireConfirmedEmail = true;
            });

            return services;
        }
    }
}
