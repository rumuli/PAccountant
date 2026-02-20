using Microsoft.EntityFrameworkCore;
using Domain.Entities;
<<<<<<< HEAD
=======
using Application.Domain.Entities;
>>>>>>> 08f1fd072ddb096e219a84fc5aec1797c88499a8
namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {           
        }
        public DbSet<Account> Accounts{get;set;}
        public DbSet<AccountType> AccountTypes{get;set;}
        public DbSet<Person> Persons{get;set;}
        public DbSet<Property> Properties{get;set;}
        public DbSet<PropertyCategory> PropertyCategories{get;set;}
<<<<<<< HEAD
=======
          public DbSet<Debt> Debts{get;set;}
            public DbSet<Expense> Expenses{get;set;}
              public DbSet<Income> Incomes{get;set;}
                public DbSet<IncomeType> IncomeTypes{get;set;}
                  public DbSet<PaymentMethod> PaymentMethods{get;set;}
                    public DbSet<ExpensePlanning> ExpensePlannings{get;set;}
                      public DbSet<IncomePlanning> IncomePlannings{get;set;}
                        public DbSet<Budget> Budgets{get;set;}
                          public DbSet<ExpenseType> ExpenseTypes{get;set;}
>>>>>>> 08f1fd072ddb096e219a84fc5aec1797c88499a8

        
    }
}