using LCB_Clone.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class LegislatorEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public LegislatorEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetLegislators_ReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/api/legislator");
        Console.WriteLine(response);
        response.EnsureSuccessStatusCode();
    }
}

