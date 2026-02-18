using Data;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<Context>();
/**
 * injecting the services using dependency injection
 */
builder.Services.AddTransient<ICitiesWeatherService, CitiesWeatherService>();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();
 