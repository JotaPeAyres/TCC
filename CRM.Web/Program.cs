using CRM.Core;
using CRM.Core.Handlers;
using CRM.Web;
using CRM.Web.Handlers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services
    .AddHttpClient(WebConfiguration.HttpClientName, options =>
    {
        options.BaseAddress = new Uri(Configuration.BackendUrl);
    });

builder.Services.AddTransient<ICidadeHandler, CidadeHandler>();

await builder.Build().RunAsync();
