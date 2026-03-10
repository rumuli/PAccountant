using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Identity;


namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {           
        }
        public DbSet<Account> Accounts{get;set;}
        public DbSet<AccountType> AccountTypes{get;set;}
        public DbSet<Person> Persons{get;set;}
        public DbSet<Property> Properties{get;set;}
        public DbSet<PropertyCategory> PropertyCategories{get;set;}
        public DbSet<Debt> Debts{get;set;}
        public DbSet<Expense> Expenses{get;set;}
        public DbSet<DebtType> DebtTypes{get;set;}
        public DbSet<Income> Incomes{get;set;}
        public DbSet<IncomeType> IncomeTypes{get;set;}
        public DbSet<PaymentMethod> PaymentMethods{get;set;}
        public DbSet<ExpensePlanning> ExpensePlannings{get;set;}
        public DbSet<IncomePlanning> IncomePlannings{get;set;}
        public DbSet<Budget> Budgets{get;set;}
        public DbSet<ExpenseType> ExpenseTypes{get;set;}
        public DbSet<Lend> Lends{get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Customize identity table
             builder.Entity<User>().ToTable("Users");
             builder.Entity<IdentityRole<int>>().ToTable("Roles");
             builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
             builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
             builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
             builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
             builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
             builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(ur => new { ur.UserId, ur.RoleId });

             builder.Entity<Budget>().Property(t=> t.Status).HasConversion<string>();
             builder.Entity<Account>().Property(t=> t.Status).HasConversion<string>();


        }
        
    }
}