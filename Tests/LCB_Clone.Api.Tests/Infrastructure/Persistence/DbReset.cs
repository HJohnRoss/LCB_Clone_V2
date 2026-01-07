using MySqlConnector;
using Respawn;

namespace LCB_Clone.Api.Tests.Infrastructure.Persistence;

public sealed class DbReset(string connectionString)
{
	private readonly string _connectionString = connectionString;
	private Respawner? _respawner;

	public async Task InitializeAsync()
	{
		await using var conn = new MySqlConnection(_connectionString);
		await conn.OpenAsync();

		_respawner = await Respawner.CreateAsync(conn, new RespawnerOptions
		{
			DbAdapter = DbAdapter.MySql,
			// Keep migrations table
			TablesToIgnore = ["__EFMigrationsHistory"]
		});
	}

	public async Task ResetAsync()
	{
		if (_respawner is null)
			throw new InvalidOperationException("DbReset not initialized. Call InitializeAsync() first.");

		await using var conn = new MySqlConnection(_connectionString);
		await conn.OpenAsync();

		await _respawner.ResetAsync(conn);
	}
}

