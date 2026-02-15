var builder = WebApplication.CreateBuilder(args);
/**
 * adds controllers and their views
 */
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
