using NLog;
using NLog.Web;
using Microsoft.OpenApi.Models;
using VkNet.Enums.StringEnums;

LogManager.Setup().LoadConfigurationFromAppSettings();
var logger = LogManager.GetCurrentClassLogger();

VkService.Initialize();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VkApp API", Version = "v1" });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VkApp API v1");
    c.RoutePrefix = string.Empty;
});

app.UseRouting();
app.MapControllers();

logger.Trace("Старт приложения");
app.Run();