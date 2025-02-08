using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MudBlazor.Services;
using ShirtStorm.Components;
using ShirtStorm.Shared;
using System.Reflection;

var kvUri = "https://shirt-storm-vault.vault.azure.net/";
var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
var secret = await client.GetSecretAsync("appsettingscipher");

var builder = WebApplication.CreateBuilder(args);
if (secret != null)
{ 
    // Read the connection string from the appsettings.json file
    builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    // Get HostingEnvironment
    var env = builder.Environment;
    builder.Configuration.AddJsonFile($"appsettings{env.EnvironmentName}.json", optional: true);
    builder.Configuration.Decrypt(secret.Value.Value);
}

builder.Configuration.AddEnvironmentVariables().AddUserSecrets(Assembly.GetExecutingAssembly(), true);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddMicrosoftIdentityConsentHandler();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextAccessor>();
// This is where we wire up to events to detect when a user logs in
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(options =>
    {
        builder.Configuration.Bind("AzureAdB2C", options);
        options.Events = new OpenIdConnectEvents
        {
            OnRedirectToIdentityProvider = async ctxt =>
            {
                // after successful login take customers to their subscription page
                ctxt.Properties.RedirectUri = "/upcoming";
                await Task.Yield();
            },
            OnSignedOutCallbackRedirect = async ctxt =>
            {
                ctxt.HttpContext.Response.Redirect(ctxt.Options.SignedOutRedirectUri);
                ctxt.HandleResponse();
                await Task.Yield();
            },
        };
    });

if (secret != null && builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ShirtStormDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
