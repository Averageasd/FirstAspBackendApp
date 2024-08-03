using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext httpContext) =>
{
    
    // Request Body is a stream 
    StreamReader streamReader = new StreamReader(httpContext.Request.Body);
    // read it into a string using streamReader
    string body = await streamReader.ReadToEndAsync();

    // parse query string and put them in dictionary
    // ex: name=ng&age=20 => {name:[ng], age:[20]}
    Dictionary<string, StringValues> queries = QueryHelpers.ParseQuery(body);
    if (queries.ContainsKey("firstName"))
    {
        string firstName = queries["firstName"][0];
        await httpContext.Response.WriteAsync(firstName);
    }
});

app.Run();