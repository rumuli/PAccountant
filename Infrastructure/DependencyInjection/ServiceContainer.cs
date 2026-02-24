using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Application.Services.IncomeTypes;
using Application.Services.ExpenseTypes;
using Application.Services.Incomes;
using Application.Services.Expenses;
using Application.Services.PaymentMethods;
using Application.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register ApplicationDbContext (service here) with SQL Server provider
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("PAccountantDBCONN")),ServiceLifetime.Scoped
                );

            //register repository
            services.AddScoped<IExpenseType, ExpenseTypeRepository>();
            services.AddScoped<IIncomeType, IncomeTypeRepository>();
            services.AddScoped<IIncome, IncomeRepository>();
            services.AddScoped<IExpense, ExpenseRepository>();
            services.AddScoped<IPaymentMethod, PaymentMethodRepository>();


            return services;
        }
    }
}