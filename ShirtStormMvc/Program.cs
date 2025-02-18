using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using ShirtStormMvc.Extensions;

// get key to appsetttings encryption
var kvUri = "https://shirt-storm-vault.vault.azure.net/";
var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
var appSettingSecret = await client.GetSecretAsync("appsettingscipher");

var builder = WebApplication.CreateBuilder(args);

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
                //ctxt.Properties.RedirectUri = "/upcoming";
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
