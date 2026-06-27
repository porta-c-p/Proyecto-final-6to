using EduMentorAI.Api.Middlewares;

namespace EduMentorAI.Api.Extensions;

public static class MiddlewareExtensions
{
    public static WebApplication UseGlobalExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionMiddleware>();
        return app;
    }
}