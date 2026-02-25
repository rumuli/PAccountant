using Web.Components;
using Infrastructure.DependencyInjection;
using Application.Services.Users;
using Application.Interfaces.Users;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    builder.Services.AddMudServices();

    builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddHttpClient();
builder.Services.AddControllers();  
builder.Services.AddAuthorization();
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

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
