using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using LCB_Clone.Api.Tests.Infrastructure.Persistence;
using LCB_Clone.Shared.Dtos.Legislators;
using Microsoft.AspNetCore.Http;

namespace LCB_Clone.Api.Tests.Features;

public class LegislatorEndpointsTests(CustomWebApplicationFactory factory)
	: IClassFixture<CustomWebApplicationFactory>, IAsyncLifetime
{
	private readonly HttpClient _client = factory.CreateClient();
	private TestData Data => new(_client);

	private readonly DbReset _dbReset = new(
			Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING")
			?? throw new InvalidOperationException("TEST_CONNECTION_STRING not set.")
			);

	async Task IAsyncLifetime.InitializeAsync()
	{
		await _dbReset.InitializeAsync();
		await _dbReset.ResetAsync();
	}

	Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;


	// --- UNIT TESTS ---
	[Fact]
	public async Task CreateLegislator_ReturnsOk()
	{
		await Data.CreateLegislatorAsync();
	}

	[Fact]
	public async Task GetAllLegislators_ReturnsOk()
	{
		await Data.CreateLegislatorAsync();

		HttpResponseMessage httpResponse =
			await _client.GetAsync("api/Legislator");

		httpResponse.EnsureSuccessStatusCode();

		List<LegislatorResponseDto>? legislators =
			await httpResponse.Content
			.ReadFromJsonAsync<List<LegislatorResponseDto>>();

		Assert.NotNull(legislators);
		Assert.NotEmpty(legislators);
	}

	[Fact]
	public async Task GetOneLegislator_ReturnOkAndLegislator()
	{
		LegislatorResponseDto created =
			await Data.CreateLegislatorAsync();

		HttpResponseMessage httpResponse =
			await _client.GetAsync($"api/Legislator/{created.Id}");

		httpResponse.EnsureSuccessStatusCode();

		LegislatorResponseDto? legislator =
			await httpResponse.Content
			.ReadFromJsonAsync<LegislatorResponseDto>();

		Assert.NotNull(legislator);
		legislator.Should().BeEquivalentTo(created, opts => opts
			.Excluding(l => l.Socials)
			.Excluding(l => l.LegislatorStrings));
	}

	[Fact]
	public async Task DeleteLegislator_WhenExists_ReturnsNoContent_AndThenGetNotFound()
	{
		LegislatorResponseDto created =
			await Data.CreateLegislatorAsync();

		HttpResponseMessage deleteResponse =
			await _client.DeleteAsync($"api/Legislator/{created.Id}");

		deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

		HttpResponseMessage getResponse =
			await _client.GetAsync($"api/Legislator/{created.Id}");

		getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
	}

	[Fact]
	public async Task DeleteLegislator_WhenMissing_ReturnsNotFound()
	{
		HttpResponseMessage httpResponse =
			await _client.DeleteAsync("api/Legislator/9999999");

		httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
	}
}
