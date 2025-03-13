using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MentalEdu.BlazorApp.Client;
using MentalEdu.BlazorApp.Client.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Register services
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<LoggingService>();
builder.Services.AddScoped<AppConfigurationService>();
builder.Services.AddScoped<SupportProgramService>();

await builder.Build().RunAsync();
