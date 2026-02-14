using Authentication.Application;
using Infrastructure.mongodb.Logs;
using Microsoft.Extensions.Logging;
using Shared.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllers();
builder.Services.AddApplication();
// builder.Services.AddApiCore();
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddSingleton<IApiLogWriter, MongoApiLogWriter>();

var app = builder.Build();

app.UseApiCore();
app.MapControllers();

app.Run();
