
using Microsoft.EntityFrameworkCore;    
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Application.Interfaces;
using Infrastructure.Repositories;
using Application.Services.Customers;
using Application.Services.Leads;
using Application.Services.Activities;
using Application.Services.SupportTickets;
using Application.Services.Deals;
using Application.Services.Campaigns;
using Application.Services.Notes; 
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
                options.UseSqlServer(configuration.GetConnectionString("CRMDBCONN")), ServiceLifetime.Scoped);
         

         //Register authentication services
            services.AddAuthenticationService(configuration);
 
            // Register repositories
           services.AddScoped<ICustomer, CustomerRepository>();
           services.AddScoped<ILead, LeadRepository>();
           services.AddScoped<IActivity, ActivityRepository>();
           services.AddScoped<ISupportTicket, SupportTicketRepository>();
           services.AddScoped<IDeal, DealRepository>();
           services.AddScoped<ICampaign, CampaignRepository>();
           services.AddScoped<INote, NoteRepository>();

           //register Identity services
               services.AddScoped<IIdentity, IdentityRepository>();
    
            
            
            return services;
            
        }
    }
}