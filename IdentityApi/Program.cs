using IdentityApi;
using IdentityApi.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);

startup.AddJsonFiles(builder.Configuration, builder.Environment);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

startup.ConfigureServices(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    db.Database.Migrate();
}

startup.Configure(app, app.Environment);

try
{
    Log.Information("Iniciando aplicação Web");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}