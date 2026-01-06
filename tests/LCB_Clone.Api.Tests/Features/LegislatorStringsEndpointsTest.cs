
using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using LCB_Clone.Api.Tests.Infrastructure.Persistence;
using LCB_Clone.Api.Tests.TestData;
using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Tests.Features;

public sealed class LegislatorStringsEndpointsTests : IClassFixture<CustomWebApplicationFactory>, IAsyncLifetime
{
	private readonly HttpClient _client;
	private readonly TestDataFactory _data;

	private readonly DbReset _dbReset;

	public LegislatorStringsEndpointsTests(CustomWebApplicationFactory factory)
	{
		_client = factory.CreateClient();
		_data = new TestDataFactory(_client);

		_dbReset = new DbReset(
				Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING")
				?? throw new InvalidOperationException("TEST_CONNECTION_STRING not set.")
				);
	}

	async Task IAsyncLifetime.InitializeAsync()
	{
		await _dbReset.InitializeAsync();
		await _dbReset.ResetAsync();
	}

	Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;


	// --- UNIT TESTS ---

	[Fact]
	public async Task CreateLegislatorString_ReturnsOk()
	{
		await _data.LegislatorStrings.CreateLegislatorStringAsync();
	}

	[Fact]
	public async Task GetAllLegislatorStrings_ReturnsOk()
	{
		await _data.LegislatorStrings.CreateLegislatorStringAsync();

		HttpResponseMessage httpResponse =
			await _client.GetAsync("api/LegislatorString");

		httpResponse.EnsureSuccessStatusCode();

		List<LegislatorStringsResponseDto>? legislators =
			await httpResponse.Content
			.ReadFromJsonAsync<List<LegislatorStringsResponseDto>>();

		Assert.NotNull(legislators);
		Assert.NotEmpty(legislators);
	}

	[Fact]
	public async Task GetOneLegislator_ReturnOkAndLegislator()
	{
		LegislatorStringsResponseDto created =
			await _data.LegislatorStrings.CreateLegislatorStringAsync();

		HttpResponseMessage httpResponse =
			await _client.GetAsync($"api/LegislatorString/{created.Id}");

		httpResponse.EnsureSuccessStatusCode();

		LegislatorStringsResponseDto? legislatorString =
			await httpResponse.Content
			.ReadFromJsonAsync<LegislatorStringsResponseDto>();

		Assert.NotNull(legislatorString);
		legislatorString.Should().BeEquivalentTo(created, opts => opts
			.Excluding(ls => ls.Legislator));
	}

	[Fact]
	public async Task DeleteLegislator_WhenExists_ReturnsNoContent_AndThenGetNotFound()
	{
		LegislatorStringsResponseDto created =
			await _data.LegislatorStrings.CreateLegislatorStringAsync();

		HttpResponseMessage deleteResponse =
			await _client.DeleteAsync($"api/LegislatorString/{created.Id}");

		deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

		HttpResponseMessage getResponse =
			await _client.GetAsync($"api/LegislatorString/{created.Id}");

		getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
	}

	[Fact]
	public async Task DeleteLegislator_WhenMissing_ReturnsNotFound()
	{
		HttpResponseMessage httpResponse =
			await _client.DeleteAsync($"api/LegislatorString/2147483647");

		httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
	}
}
