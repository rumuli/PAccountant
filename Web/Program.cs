using Web.Components;
using Application.Services.Customers;
using Application.Services.Campaigns;
using Application.Services.SupportTickets;
using Infrastructure.DependencyInjection;
using Application.Services.Leads;
using Application.Services.Deals;
using Application.Services.Notes;
using Application.Services.Activities;
using MudBlazor.Services;
using Application.Services.Users;
using Application.Interfaces.Users;




var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Add HttpClient for API calls
    builder.Services.AddHttpClient();

    builder.Services.AddMudServices();


   

    //dependency injections for infrastructure layer

    builder.Services.AddInfrastructureServices(builder.Configuration);

    
    //dependency injections for application layer   

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICampaignService, CampaignService>();
builder.Services.AddScoped<ISupportTicketService, SupportTicketService>();    
builder.Services.AddScoped<IDealService, DealService>(); 
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();




var app = builder.Build(); 


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

//Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();



app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();

