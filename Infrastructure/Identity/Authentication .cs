using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Identity
{
    public static class Authentication
    {
         public static IServiceCollection AddAuthenticationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultScheme = IdentityConstants.ApplicationScheme;

        }).AddIdentityCookies();

        // Configure Identity options like password strength, lockout, etc. if needed

        services.AddIdentityCore<User>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;

            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedAccount = true;
            options.Lockout.MaxFailedAccessAttempts = 3;
            
        })
          .AddRoles<IdentityRole<int>>()
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddSignInManager()
            .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                //access to the user
                options.TokenLifespan = TimeSpan.FromHours(6); // Set token lifespan as needed
            });

            services.ConfigureApplicationCookie(options =>
            {
              options.Cookie.Name = "CRM Demo"; // Set a custom cookie name
              options.Cookie.HttpOnly = true; // Set HttpOnly for security
              options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Ensure cookies are only sent over HTTPS
              options.Cookie.SameSite = SameSiteMode.Lax; // Set SameSite policy
            });

            return services;
    }
}
}
