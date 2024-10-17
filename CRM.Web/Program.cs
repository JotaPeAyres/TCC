using CRM.Web;
using CRM.Core.Handlers;
using CRM.Web.Handlers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped<CookieHandler>();
builder.Services.AddAuthorizationCore();

//builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
//builder.Services.AddScoped(x =>
//    (ICookieAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddMudServices();

builder.Services
    .AddHttpClient(Configuration.HttpClientName, options => { options.BaseAddress = new Uri(Configuration.BackendUrl); });

builder.Services.AddTransient<ICidadeHandler, CidadeHandler>();
builder.Services.AddTransient<IEstadoHandler, EstadoHandler>();
builder.Services.AddTransient<IAgendaHandler, AgendaHandler>();
builder.Services.AddTransient<IPedidoHandler, PedidoHandler>();
builder.Services.AddTransient<IProdutoHandler, ProdutoHandler>();
builder.Services.AddTransient<ITarefaHandler, TarefaHandler>();

builder.Services.AddLocalization();
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

await builder.Build().RunAsync();