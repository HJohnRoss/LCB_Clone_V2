using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using LCB_Clone.Api.Tests.Infrastructure.Persistence;
using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Tests.Features;


public class SocialEndpointsTests(CustomWebApplicationFactory factory)
	: IClassFixture<CustomWebApplicationFactory>, IAsyncLifetime
{
	private readonly HttpClient _client = factory.CreateClient();
	// --- HELPER FUNCTIONS ---
	private TestData Data => new(_client);

	// --- DB RESET ---
	private readonly DbReset _dbReset = new(
		Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING")
		?? throw new InvalidOperationException("TEST_CONNECTION_STRING not set.")
	);

	async Task IAsyncLifetime.InitializeAsync()
	{
		Console.WriteLine("[TEST] DbReset env TEST_CONNECTION_STRING = " +
		Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING"));
		await _dbReset.InitializeAsync(); // if you have this method
		await _dbReset.ResetAsync();
	}

	Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;


	// --- UNIT TESTS ---
	[Fact]
	public async Task CreateSocial_ReturnsOk()
	{
		await Data.CreateSocialAsync();
	}

	[Fact]
	public async Task GetAllSocials_ReturnsOkAndSocials()
	{
		await Data.CreateSocialAsync();

		HttpResponseMessage httpResponse =
			await _client.GetAsync("api/Social");

		httpResponse.EnsureSuccessStatusCode();

		List<SocialResponseDto>? response =
			await httpResponse.Content.ReadFromJsonAsync<List<SocialResponseDto>>();

		Assert.NotNull(response);
		Assert.NotEmpty(response);
	}

	[Fact]
	public async Task GetOneSocial_ReturnsOkAndSocial()
	{
		SocialResponseDto dto =
			await Data.CreateSocialAsync();

		HttpResponseMessage httpResponse =
			await _client.GetAsync($"api/Social/{dto.Id}");

		httpResponse.EnsureSuccessStatusCode();

		SocialResponseDto? response =
			await httpResponse.Content
			.ReadFromJsonAsync<SocialResponseDto>();

		response.Should().NotBeNull();
		response.Should().BeEquivalentTo(dto, opts => opts
			.Excluding(s => s.Legislator));
	}

	[Fact]
	public async Task DeleteSocial_WhenExists_ReturnsNoContent_AndThenGetNotFound()
	{
		SocialResponseDto dto =
			await Data.CreateSocialAsync();

		HttpResponseMessage deleteResponse =
			await _client.DeleteAsync($"api/Social/{dto.Id}");

		deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

		HttpResponseMessage getResponse =
			await _client.GetAsync($"api/Social/{dto.Id}");

		getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
	}

	[Fact]
	public async Task DeleteSocial_WhenDoesNotExist_ReturnsNotFound()
	{
		HttpResponseMessage httpResponse =
			await _client.DeleteAsync($"api/Social/999999");

		httpResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
	}
}
