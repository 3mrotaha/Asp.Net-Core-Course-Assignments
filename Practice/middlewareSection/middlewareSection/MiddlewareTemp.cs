using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace middlewareSection
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareTemp
    {
        private readonly RequestDelegate _next;

        public MiddlewareTemp(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Test ASP.NET Core Middleware Template -- start\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("Test ASP.NET Core Middleware Template -- end\n");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareTemp(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareTemp>();
        }
    }
}
