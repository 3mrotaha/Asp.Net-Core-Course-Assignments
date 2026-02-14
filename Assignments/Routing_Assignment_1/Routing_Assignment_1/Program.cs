using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

List<string> countries = new List<string>()
{
    "United States",
    "Canada",
    "United Kingdom",
    "India",
    "Japan"
};

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    // send the list of countries in the response
    endpoints.MapGet("/countries", async context =>
    {
        StringBuilder sb = new StringBuilder();
        int countryId = 1;
        foreach (var country in countries)
        {
            sb.AppendLine($"{countryId++}, {country}");
        }

        context.Response.StatusCode = 200;
        await context.Response.WriteAsync( sb.ToString() );
    });


    // if found in the defined range
    endpoints.MapGet("/countries/{id:int:range(1, 100)}", async context =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]?.ToString());
        string responseBody = "";
        if(id > countries.Count)
        {
            // not found in the list
            context.Response.StatusCode = 404;
            responseBody = "[No Country]";
        }
        else
        {
            // process the response
            responseBody = countries[id - 1];
        }

        await context.Response.WriteAsync( responseBody );
    });

    // if out of range
    endpoints.MapGet("/countries/{id:int:min(101)}", async context =>
    {
        context.Response.StatusCode = 400;        
        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
    });

    // Fallback
    endpoints.MapFallback(() => "PAGE NOT FOUND");
});
#pragma warning restore ASP0014 // Suggest using top level route registrations


app.Run();
