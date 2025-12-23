using LCB_Clone.Api.Infrastructure.Extensions;
using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Api.Features.Legislators;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace LCB_Clone.Api.Tests;

public class TestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Use InMemory DB for tests
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("TestDb"));

        services.AddCorsPolicy();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // Register handlers
        services.AddScoped<GetLegislatorsHandler>();
        services.AddScoped<GetLegislatorByIdHandler>();
        services.AddScoped<CreateLegislatorHandler>();
        services.AddScoped<DeleteLegislatorByIdHandler>();
    }

    public void Configure(WebApplication app)
    {
        app.UseCorsPolicy();
        app.UseSwaggerInDevelopment();
        app.MapLegislatorEndpoints();
    }
}

