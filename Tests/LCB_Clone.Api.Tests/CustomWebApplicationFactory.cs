using DotNetEnv;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using LCB_Clone.Api.Infrastructure.Persistence;

namespace LCB_Clone.Api.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
	private readonly string _connectionString;

	public CustomWebApplicationFactory()
	{
		// Load ONLY the test project's .env (copied to test output)
		var envPath = Path.Combine(AppContext.BaseDirectory, ".env");
		if (!File.Exists(envPath))
		{
			throw new InvalidOperationException(
				$"Test .env not found at: {envPath}. Set it to Copy to Output Directory.");
		}

		// DotNetEnv version in your project doesn't support overwriteExistingVars
		Env.Load(envPath);

		_connectionString =
			Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING")
			?? throw new InvalidOperationException("TEST_CONNECTION_STRING not set in test .env.");
	}

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.UseEnvironment("Test");

		// Force API config to use the test DB
		builder.ConfigureAppConfiguration((_, configBuilder) =>
		{
			configBuilder.AddInMemoryCollection(new Dictionary<string, string?>
			{
				["ConnectionStrings:Default"] = _connectionString
			});
		});

		builder.ConfigureServices(services =>
		{
			// Remove EF registrations
			services.RemoveAll<AppDbContext>();
			services.RemoveAll<DbContextOptions<AppDbContext>>();
			services.RemoveAll<DbContextOptions>();
			services.RemoveAll<IDbContextFactory<AppDbContext>>();

			// Re-register context with test connection string
			services.AddDbContext<AppDbContext>(options =>
				options.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString)));

			// Validate + migrate
			var sp = services.BuildServiceProvider();
			using var scope = sp.CreateScope();

			var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			var conn = db.Database.GetDbConnection();

			if (!conn.Database.Contains("test", StringComparison.OrdinalIgnoreCase))
			{
				throw new InvalidOperationException(
					$"Refusing to run tests on non-test database '{conn.Database}'.");
			}

			db.Database.Migrate();
		});
	}
}

