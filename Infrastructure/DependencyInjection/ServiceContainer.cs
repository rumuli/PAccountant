using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Application.Services.IncomeTypes;
using Application.Services.ExpenseTypes;
using Application.Services.Incomes;
using Application.Services.Expenses;
using Application.Services.PaymentMethods;
using Application.Services.Debts;
using Application.Services.DebtTypes;
using Application.Services.BudgetServices;
using Application.Services.IncomePlanningServices;
using Application.Services.ExpensePlanningServices;
using Application.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Identity;
using System.Diagnostics;

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

                
         //Register authentication services
            services.AddAuthenticationService(configuration);

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


            return services;
        }
    }
}