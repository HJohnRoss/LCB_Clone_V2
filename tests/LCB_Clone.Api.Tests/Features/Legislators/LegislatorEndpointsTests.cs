using Xunit;

public class LegislatorEndpointsTests
    : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public LegislatorEndpointsTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetLegislators_ReturnsSuccess()
    {
        var response = await _client.GetAsync("/api/legislators");

        response.EnsureSuccessStatusCode();
    }
}

