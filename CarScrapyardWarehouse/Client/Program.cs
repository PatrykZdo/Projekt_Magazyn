using CarScrapyardWarehouse.Client;
using CarScrapyardWarehouse.Client.Interfaces;
using CarScrapyardWarehouse.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudExtensions.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices(config =>
{
	config.PopoverOptions.ThrowOnDuplicateProvider = false;
});
builder.Services.AddMudExtensions();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IAllegroService, AllegroService>();
builder.Services.AddScoped<IHttpService, HttpService>();

builder.Services.AddHttpClient("CarScrapyardWarehouse.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CarScrapyardWarehouse.ServerAPI"));
var authority = builder.Configuration.GetValue<string>("Okta:Authority");
var clientId = builder.Configuration.GetValue<string>("Okta:ClientId");

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = authority;
    options.ProviderOptions.ClientId = clientId;
    options.ProviderOptions.ResponseType = "code";
});

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
