using Microsoft.EntityFrameworkCore;
using Domain.Entities;
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

        
    }
}