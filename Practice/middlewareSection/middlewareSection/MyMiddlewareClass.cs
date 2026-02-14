
namespace middlewareSection
{
    public class MyMiddlewareClass : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Middleware start\n");
            await next(context);
            await context.Response.WriteAsync("My Middleware end\n");
        }
    }

    public static class MyMiddlewareExtenstions
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddlewareClass>();            
        }
    }




}
