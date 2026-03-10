using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Infrastructure.Repository;
using Application.Interfaces;
using Infrastructure.Repositories;
using Application.Services.IncomeTypeServices;
using Application.Services.ExpenseTypes;
using System.Diagnostics;
using Infrastructure.Identity;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
         public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
           //Add Infrastructure services here, e.g., DbContext, Repositories, etc.
              services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PAccountant")),ServiceLifetime.Scoped);
                
         //Register authentication services
            services.AddAuthenticationService(configuration);

            services.AddHttpContextAccessor();
              services.AddScoped<IUserContext, UserContext>();

            //register repository
            services.AddScoped<IExpenseType, ExpenseTypeRepository>();
            services.AddScoped<IIncomeType, IncomeTypeRepository>();
            services.AddScoped<IIncome, IncomeRepository>();
            services.AddScoped<IExpense, ExpenseRepository>();
            services.AddScoped<IPaymentMethod, PaymentMethodRepository>();
            services.AddScoped<IDebt, DebtRepository>();
            services.AddScoped<IDebtType, DebtTypeRepository>();
            services.AddScoped<IBudget, BudgetRepository>();
            services.AddScoped<IIncomePlanning, IncomePlanningRepository>();
            services.AddScoped<IExpensePlanning, ExpensePlanningRepository>();
            services.AddScoped<IIdentity, IdentityRepository>();
             services.AddScoped<IAccount, AccountRepository>(); 
            services.AddScoped<IAccountType, AccountTypeRepository>(); 
            services.AddScoped<IPerson, PersonRepository>(); 


            services.AddScoped<IProperty, PropertyRepository>(); 
            services.AddScoped<IPropertyCategory, PropertyCategoryRepository>(); 
                

              
              return services;
        }
    }
}