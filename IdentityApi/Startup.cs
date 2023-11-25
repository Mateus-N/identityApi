using IdentityApi.Data;
using IdentityApi.MarkupInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

namespace IdentityApi;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = Configuration.GetConnectionString("UsuarioConnection")!;

        services.AddDbContext<UserDbContext>(opts =>
            opts.UseMySQL(connectionString)
        );
        services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(opts =>
            opts.User.RequireUniqueEmail = true
        )
        .AddEntityFrameworkStores<UserDbContext>()
        .AddDefaultTokenProviders();

        AddInjectableServices(services);

        services.AddControllers();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseSerilogRequestLogging();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private static void AddInjectableServices(IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type markupInterface = typeof(IInjectable);

        List<Type> injectableClasses = assembly.GetTypes()
            .Where(t => markupInterface.IsAssignableFrom(t) && !t.IsInterface)
            .ToList();

        foreach (Type injectableClass in injectableClasses)
        {
            Type serviceInterface = injectableClass.GetInterfaces()
                .First(i => i.Name == $"I{injectableClass.Name}");

            services.AddScoped(serviceInterface, injectableClass);
        }
    }

    public void AddJsonFiles(IConfigurationBuilder builder, IWebHostEnvironment env)
    {
        builder
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
            .AddJsonFile("applogger.json")
            .AddJsonFile($"applogger.{env.EnvironmentName}.json");
    }
}
