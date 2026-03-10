using Web.Components;
using MudBlazor.Services;
using Infrastructure.DependencyInjection;
using Application.Services.BudgetServices;
using Application.Services.IncomePlanningServices;
using Application.Interfaces;
using Application.Services.ExpensePlanningServices;
using Application.Services.IncomeTypes;
using Application.Services.ExpenseTypes;
using Application.Services.Incomes;
using Application.Services.Expenses;
using Application.Services.Debts;
using Application.Services.PaymentMethods;
using Application.Services.DebtTypes;
using Application.Services.Users;
using Application.Services.Accounts;
using Application.Services.AccountTypes;
using Application.Services.Properties;
using Application.Services.PropertyCategories;
using Application.Services.Persons;




var builder = WebApplication.CreateBuilder(args);



builder.Services.AddMudServices();//mudblazor services for UI components

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<IExpensePlanningService, ExpensePlanningService>();
builder.Services.AddScoped<IIncomePlanningService, IncomePlanningService>();
builder.Services.AddScoped<IIncomeTypeService, IncomeTypeService>();
builder.Services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddScoped<IDebtService, DebtService>();
builder.Services.AddScoped<IDebtTypeService, DebtTypeService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountTypeService, AccountTypeService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IPropertycategoryService, PropertyCategoryService>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddHttpClient();
builder.Services.AddControllers();  
builder.Services.AddAuthorization();



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

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();