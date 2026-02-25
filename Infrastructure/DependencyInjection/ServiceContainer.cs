using Microsoft.EntityFrameworkCore;    
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Application.Interfaces;

using System.Diagnostics;
using Infrastructure.Identity;


namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Example: Adding a DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PACCCONN")), ServiceLifetime.Scoped);
         

         //Register authentication services
            services.AddAuthenticationService(configuration);
 
     

           //register Identity services
              services.AddScoped<IIdentity, IdentityRepository>();
    
            
            
            return services;
            
        }
    }
}