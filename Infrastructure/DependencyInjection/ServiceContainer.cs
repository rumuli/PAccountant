using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Infrastructure.Repository;
using Application.Interfaces;
using Infrastructure.Repositories;
using Application.Services.IncomeTypeServices;
using Application.Services.ExpenseTypes;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
         public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
           //Add Infrastructure services here, e.g., DbContext, Repositories, etc.
              services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PAccountant")),ServiceLifetime.Scoped);
                
                // services.AddAuthenticationService(configuration);
                services.AddScoped<IBudget, BudgetRepository>();
                services.AddScoped<IIncomePlanning, IncomePlanningRepository>();
                services.AddScoped<IIncomeType, IncomeTypeRepository>();
                services.AddScoped<IExpenseType, ExpenseTypeRepository>();
                services.AddScoped<IExpensePlanning, ExpensePlanningRepository>();
                // services.AddScoped<IUser, UserRepository>();

              
              return services;
        }
    }
}