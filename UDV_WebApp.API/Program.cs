using NLog;
using Microsoft.OpenApi.Models;
using UDV_WebApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using UDV_WebApp.Core.Abstractions;
using UDV_WebApp.Core.Models;
using UDV_WebApp.DataAccess.Repositories;
using UDV_WebApp.Application.Services;

LogManager.Setup();
var logger = LogManager.GetCurrentClassLogger();

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VkApp API", Version = "v1" });
});

services.AddDbContext<VkAppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(VkAppDbContext)));
});

services.AddScoped<IRepository<CountResult>, CountResultRepository>();
services.AddScoped<IVkService, VkService>();
services.AddScoped<IStatisticsService, StatisticsService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VkApp API v1");
    c.RoutePrefix = string.Empty;
});

app.UseRouting();
app.MapControllers();

logger.Debug("Application starting");
app.Run();