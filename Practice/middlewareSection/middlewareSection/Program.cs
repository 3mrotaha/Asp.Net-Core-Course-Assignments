using middlewareSection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyMiddlewareClass>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!\n");

// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello 1 -- start\n");
    await next(context);
    await context.Response.WriteAsync("Hello 1 -- end\n");
});

app.UseWhen(
        context => context.Request.Query.ContainsKey("name"),
        app => app.UseMiddlewareTemp()
    );

// middleware 2
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello 2 -- start\n");
    await next(context);
    await context.Response.WriteAsync("Hello 2 -- end\n");
});

// my custome middleware 3
app.UseMyCustomMiddleware();

// middleware 4
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello 5 -- start\n");
    await context.Response.WriteAsync("Hello 5 -- end\n");
});


app.Run();
