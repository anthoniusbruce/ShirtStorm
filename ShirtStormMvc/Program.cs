using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using ShirtStormMvc.Database;
using ShirtStormMvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

// get key to appsetttings encryption
var kvUri = "https://shirt-storm-vault.vault.azure.net/";
var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
var appSettingSecret = await client.GetSecretAsync("appsettingscipher");

// ready the appsettings file
// Read the connection string from the appsettings.json file
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Configuration.Decrypt(appSettingSecret.Value.Value);

// Add Azure AD configuration
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(options =>
    {
        builder.Configuration.Bind("AzureAdB2C", options);
        options.Events = new OpenIdConnectEvents
        {
            OnRedirectToIdentityProvider = async ctxt =>
            {
                // after successful login take customers to their subscription page
                ctxt.Properties.RedirectUri = "/Home/UpcomingDesigns";
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

var retryStrategy = new Action<SqlServerDbContextOptionsBuilder>(
    sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
        maxRetryCount: 10,
        maxRetryDelay: TimeSpan.FromSeconds(30),
        errorNumbersToAdd: null);
    });
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ShirtStormDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), retryStrategy));
}
else
{
    var connectionSecret = await client.GetSecretAsync("shirtstormdb");
    var connectionString = string.Format(builder.Configuration.GetConnectionString("AzureConnection")!, connectionSecret.Value.Value);
    builder.Services.AddDbContext<ShirtStormDbContext>(options => options.UseSqlServer(connectionString, retryStrategy));
}

// Add services to the container.
builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
