using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    var method = context.Request.Method;
    var path = context.Request.Path;

    StringBuilder response = new StringBuilder();

    if(path == "/" && method == "GET")
    {
        bool error = false;
        int fNumber = 0, sNumber = 0;
        Func<int, int, float> operationHandler = (n1, n2) => n1 + n2;

        if (!context.Request.Query.ContainsKey("firstNumber")
            || string.IsNullOrWhiteSpace(context.Request.Query["firstNumber"])
            || !int.TryParse(context.Request.Query["firstNumber"], out fNumber))
        {
            response.AppendLine("Invalid input for firstNumber");
            error = true;
        }

        if (!context.Request.Query.ContainsKey("secondNumber") 
            || string.IsNullOrWhiteSpace(context.Request.Query["secondNumber"])
            || !int.TryParse(context.Request.Query["secondNumber"], out sNumber)       
            || ((new string[] { "divide", "mod" })
                    .Any(op => op == context.Request.Query["operation"]) && sNumber == 0))
        {
            error = true;
            response.AppendLine("Invalid input for secondNumber");
        }
        

        if (context.Request.Query.ContainsKey("operation")
                && (new string[] { "add", "multiply", "subtract", "divide", "mod"})
                    .Any(op => op == context.Request.Query["operation"]))
        {
            operationHandler = context.Request.Query["operation"].ToString().ToLower() switch
            {
                "add" => (n1, n2) => n1 + n2,
                "subtract" => (n1, n2) => n1 - n2,
                "multiply" => (n1, n2) => n1 * n2,
                "divide" => (n1, n2) => (float)n1 / n2,
                "mod" => (n1, n2) => n1 % n2,
                _ => (n1, n2) => n1 + n2
            };
        }
        else
        {
            response.AppendLine("Invalid input for operation");
            error = true;
        }

        if (error)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(response.ToString());
            return;
        }


        // perform operation
        float result = operationHandler.Invoke(fNumber, sNumber);
        response.AppendLine(result.ToString());

        context.Response.StatusCode = 200;
        await context.Response.WriteAsync(response.ToString());
    }
});

app.Run();
