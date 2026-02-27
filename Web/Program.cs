using Web.Components;
using MudBlazor.Services;
using Infrastructure.DependencyInjection;
using Application.Services.Accounts;
using Application.Services.AccountTypes;
using Application.Interface;
using Application.Services.Properties;
using Application.Services.PropertyCategories;
using Application.Services.Persons;
// using Application.Services.Accounts;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();//mudblazor services for UI components

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddInfrastructureServices(builder.Configuration);

 builder.Services.AddScoped<IAccountService, AccountService>();
 builder.Services.AddScoped<IAccountTypeService, AccountTypeService>();
 builder.Services.AddScoped<IPropertyService, PropertyService>();
 builder.Services.AddScoped<IPropertycategoryService, PropertyCategoryService>();
 builder.Services.AddScoped<IPersonService, PersonService>();



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

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

