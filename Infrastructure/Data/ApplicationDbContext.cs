
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Identity;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<SupportTicket> SupportTickets { get; set; }
         public DbSet<Lead> Leads { get; set; }
         public DbSet<Deal> Deals { get; set; } 
         public DbSet<Note> Notes { get; set; }
         public DbSet<Activity> Activities { get; set; }
        //  public DbSet<User> Users { get; set; }
        
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

        }
    
        
    }
}