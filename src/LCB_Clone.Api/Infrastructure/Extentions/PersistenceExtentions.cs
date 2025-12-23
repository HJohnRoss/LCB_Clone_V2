using LCB_Clone.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LCB_Clone.Api.Infrastructure.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        // Register DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(
                config.GetConnectionString("Default"),
                ServerVersion.AutoDetect(config.GetConnectionString("Default"))
            )
        );

        return services;
    }
}

