using DotNetEnv;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using LCB_Clone.Api.Infrastructure.Persistence;
using Microsoft.Extensions.Hosting;

namespace LCB_Clone.Api.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
	private readonly string _connectionString;

	public CustomWebApplicationFactory()
	{
		var envPath = Path.Combine(AppContext.BaseDirectory, ".env");
		if (!File.Exists(envPath))
			throw new InvalidOperationException($"Test .env not found at: {envPath}");

		Env.Load(envPath);

		_connectionString =
			Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING")
			?? throw new InvalidOperationException("TEST_CONNECTION_STRING not set in test .env.");
	}

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.UseEnvironment("Test");

		builder.ConfigureAppConfiguration((_, configBuilder) =>
		{
			configBuilder.AddInMemoryCollection(new Dictionary<string, string?>
			{
				["ConnectionStrings:Default"] = _connectionString
			});
		});

		builder.ConfigureServices(services =>
		{
			services.RemoveAll<AppDbContext>();
			services.RemoveAll<DbContextOptions<AppDbContext>>();

			services.AddDbContext<AppDbContext>(options =>
				options.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString)));
		});
	}

	protected override IHost CreateHost(IHostBuilder builder)
	{
		var host = base.CreateHost(builder);

		using var scope = host.Services.CreateScope();
		var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

		var conn = db.Database.GetDbConnection();
		if (!conn.Database.Contains("test", StringComparison.OrdinalIgnoreCase))
			throw new InvalidOperationException($"Refusing to run tests on '{conn.Database}'.");

		db.Database.Migrate();
		return host;
	}
}

