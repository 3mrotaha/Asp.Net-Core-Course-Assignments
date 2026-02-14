using Middleware_Assignment_1;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseWhen(
    context => context.Request.Method == "GET",
    async app =>
    {
        app.Run(async context =>
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync("No Response");
        });
    });

app.UseWhen(
    context => context.Request.Method == "POST",
    app =>
    {
        app.UseLoginMiddleware();
    });



app.Run();
