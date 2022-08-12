using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureRouteHandlerJsonOptions((options) =>
{
    options.SerializerOptions.AddContext<ApplicationJsonSerializerContext>();
});

var app = builder.Build();

app.MapGet("/echo", (string? text) =>
{
    if (string.IsNullOrEmpty(text))
    {
        return Results.Problem(statusCode: StatusCodes.Status400BadRequest);
    }

    return Results.Ok(new Message(text));
});

app.Run();

public record Message(string Text);

[JsonSerializable(typeof(Message))]
[JsonSerializable(typeof(ProblemDetails))]
public sealed partial class ApplicationJsonSerializerContext : JsonSerializerContext
{
}
