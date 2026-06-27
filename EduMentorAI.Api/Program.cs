using EduMentorAI.Api.Extensions;
using EduMentorAI.Application.Extensions;
using EduMentorAI.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerDocumentation();

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseGlobalExceptionHandler();

app.UseSwaggerDocumentation();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapGet("/", () => "EduMentor AI API ejecutándose correctamente.");

app.MapControllers();

app.Run();