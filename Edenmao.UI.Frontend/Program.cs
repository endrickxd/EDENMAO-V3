using Edenmao.UI.Frontend;
using Edenmao.UI.Frontend.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7118/") });
builder.Services.AddScoped<PersonificacionesServices>();
builder.Services.AddScoped<ArticuloServices>();
builder.Services.AddScoped<CategoriaServices>();
builder.Services.AddScoped<ClienteServices>();
builder.Services.AddScoped<RolServices>();
builder.Services.AddScoped<UsuarioServices>();

await builder.Build().RunAsync();
