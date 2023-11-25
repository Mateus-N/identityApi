using ApiGateway;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile($"ocelot.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost"));
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// app.UseMiddleware<RedisMiddleware>();
await app.UseOcelot();

app.Run();