using Configurator.Data;
using Configurator.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Configurator;

public static class ServiceInjection
{
    public static void ConfigureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPackagesService, PackagesService>();

        using var scope = services.BuildServiceProvider().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}