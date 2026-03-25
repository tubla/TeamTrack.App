using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using TeamTrack.App;
using TeamTrack.App.Handlers;
using TeamTrack.App.Services.Admin;
using TeamTrack.App.Services.Auth;
using TeamTrack.App.Services.Dashboard;
using TeamTrack.App.Services.Organization;
using TeamTrack.App.Services.Project;
using TeamTrack.App.Services.Role;
using TeamTrack.App.Services.Task;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                     .AddJsonFile($"appsettings.{builder.HostEnvironment.Environment}.json", optional: true, reloadOnChange: false);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

if (string.IsNullOrWhiteSpace(apiBaseUrl))
    throw new Exception("ApiBaseUrl is missing in configuration");

builder.Services.AddTransient<TokenHandler>();
builder.Services.AddTransient<OrganizationHeaderHandler>();

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
})
.AddHttpMessageHandler<TokenHandler>()
.AddHttpMessageHandler<OrganizationHeaderHandler>();


builder.Services.AddScoped(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    return factory.CreateClient("ApiClient");
});

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = true;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    // etc. – keep your existing config
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAdminAccessService, AdminAccessService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskService, TaskService>();

await builder.Build().RunAsync();
