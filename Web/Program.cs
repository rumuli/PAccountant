using Web.Components;
using MudBlazor.Services;
using Infrastructure.DependencyInjection;
using Application.Services.BudgetServices;
using Application.Services.IncomePlanningServices;
using Application.Interfaces;
using Application.Services.ExpensePlanningServices;
using Application.Services.ExpenseTypes;
using Application.Services.IncomeTypeServices;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();//mudblazor services for UI components

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<IExpensePlanningService, ExpensePlanningService>();
builder.Services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
builder.Services.AddScoped<IIncomeTypeService, IncomeTypeService>();
builder.Services.AddScoped<IIncomePlanningService, IncomePlanningService>();
builder.Services.AddInfrastructureServices(builder.Configuration);

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

