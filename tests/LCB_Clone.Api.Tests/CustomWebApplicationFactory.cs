using LCB_Clone.Api;
using LCB_Clone.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test"); // Optional

        builder.ConfigureServices(services =>
        {
            // Remove real DB context
            services.RemoveAll<DbContextOptions<AppDbContext>>();

            // Add InMemory DB
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            // Seed test data
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();

            db.Legislators.Add(new LCB_Clone.Api.Infrastructure.Persistence.Entities.Legislator
            {
                FirstName = "Alice",
                LastName = "Smith",
                Party = "Independent",
                County = "Clark",
                Email = "alice@legislature.gov",
                TermEndYear = 2025
            });

            db.SaveChanges();
        });
    }
}

