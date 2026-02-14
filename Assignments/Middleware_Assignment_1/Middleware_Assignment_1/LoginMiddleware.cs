using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Middleware_Assignment_1
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _correctEmail = "admin@example.com";
        private readonly string _correctPassword = "admin1234";
        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            StreamReader reader = new StreamReader(httpContext.Request.Body);
            string body = await reader.ReadToEndAsync();
            Dictionary<string, StringValues> queryDic =
                Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

            httpContext.Response.StatusCode = 400;

            if(queryDic.ContainsKey("email") && queryDic.ContainsKey("password"))
            {
                if (queryDic["email"][0] == _correctEmail && queryDic["password"][0] == _correctPassword)
                {
                    httpContext.Response.StatusCode = 200;
                    await httpContext.Response.WriteAsync("Successful Login\n");
                }
                else
                {
                    await httpContext.Response.WriteAsync("Invalid Login\n");
                }
            }
            else
            {
                if(!queryDic.ContainsKey("email"))
                    await httpContext.Response.WriteAsync("Invalid input for 'Email'\n");

                if (!queryDic.ContainsKey("password"))
                    await httpContext.Response.WriteAsync("Invalid input for 'Password'\n");
            }

            //await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
