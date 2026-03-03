using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Application.Interface;
using Application.Services.AccountTypes;



namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PAccountantMSSQLConnection")),ServiceLifetime.Scoped );

            services.AddScoped<IAccount, AccountRepository>(); 
            services.AddScoped<IAccountType, AccountTypeRepository>(); 
            services.AddScoped<IPerson, PersonRepository>(); 
            services.AddScoped<IProperty, PropertyRepository>(); 
            services.AddScoped<IPropertyCategory, PropertyCategoryRepository>(); 

            return services;
        }
    }
}