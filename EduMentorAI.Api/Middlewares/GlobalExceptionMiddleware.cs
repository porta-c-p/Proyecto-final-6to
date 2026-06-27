using System.Net;
using System.Text.Json;
using EduMentorAI.Application.Dtos;

namespace EduMentorAI.Api.Middlewares;

public sealed class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error no controlado en la aplicación.");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ApiResponse<string> response = new(
                false,
                "Ocurrió un error interno en el servidor.",
                null);

            string json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }
    }
}