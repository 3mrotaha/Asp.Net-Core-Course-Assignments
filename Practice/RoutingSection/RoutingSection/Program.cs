var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", () => "Hello World!");
    endpoints.Map("files/{filename:length(3, 10)}/{extension:regex(\\.[a-zA-Z]+)=.txt}", async context =>
    {
        await context.Response.WriteAsync($"filesssssssss! " +
            $"{Convert.ToString(context.Request.RouteValues["filename"])}" +
            $" - {Convert.ToString(context.Request.RouteValues["extension"])}");
    });

    endpoints.Map("employees/profile/{id:int:min(1):max(1000)=15}", async context =>
    {
        await context.Response.WriteAsync($"emplyee! id -> " +
            $"{Convert.ToString(context.Request.RouteValues["id"])}");
    });

    endpoints.Map("employees/profile/{emp-fname:alpha:maxlength(100):minlength(3)=Amr}/{emp-lname:alpha:maxlength(100):minlength(3)=Taha}", async context =>
    {
        await context.Response.WriteAsync($"emplyee! " +
            $"{Convert.ToString(context.Request.RouteValues["emp-fname"])}" +
            $" {Convert.ToString(context.Request.RouteValues["emp-lname"])}");
    });


    endpoints.Map("daily-digest-report/{reportdate:datetime}", async context =>
    {
        await context.Response.WriteAsync($"report date! date -> " +
            $"{Convert.ToDateTime(context.Request.RouteValues["r eportdate"])}");
    });

    endpoints.MapFallback(() => "NOT FOUND");

});
#pragma warning restore ASP0014 // Suggest using top level route registrations




app.Run();
