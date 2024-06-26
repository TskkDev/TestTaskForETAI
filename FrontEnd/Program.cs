using FrontEnd;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fluxor;
using FrontEnd.Features.Category.Service;
using FrontEnd.Features.Category.Interfaces;
using FrontEnd.Features.Goods.Interfaces;
using FrontEnd.Features.Goods.Services;
using FrontEnd.Shared.Service.ErrorService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IErrorService>(sp => new ErrorService());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<ICategoryService>(sp => new CategoryService(new HttpClient(),  
    builder.Configuration.GetValue<string>("Host"), sp.GetRequiredService<IErrorService>()));
builder.Services.AddTransient<IGoodService>(sp => new GoodService(new HttpClient(), 
    builder.Configuration.GetValue<string>("HostGoods"), sp.GetRequiredService<IErrorService>()));

builder.Services.AddFluxor(o =>
{
    o.ScanAssemblies(typeof(Program).Assembly);
    o.UseReduxDevTools(rdt =>
    {
        rdt.Name = "My application";
    });
});

await builder.Build().RunAsync();
