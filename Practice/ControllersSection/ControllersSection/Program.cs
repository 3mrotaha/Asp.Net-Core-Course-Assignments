using ControllersSection.Controllers;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<MyFirstController>();
builder.Services.AddControllers();
var app = builder.Build();

app.UseStaticFiles();


app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
