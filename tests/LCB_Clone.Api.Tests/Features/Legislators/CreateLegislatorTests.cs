using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using LCB_Clone.Shared.Dtos.Legislators;
using Xunit;

namespace LCB_Clone.Api.Tests.Features.Legislators;

public class CreateLegislatorTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public CreateLegislatorTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateLegislator_Returns201AndLegislator()
    {
        var dto = new LegislatorCreateDto
        {
            FirstName = "Jane",
            LastName = "Doe",
            Party = "Independent",
            County = "Clark",
            Email = "jane@legislature.gov",
            TermEndYear = 2028
        };

        var response = await _client.PostAsJsonAsync("/api/legislators", dto);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var legislator =
            await response.Content.ReadFromJsonAsync<LegislatorResponse>();

        legislator!.FirstName.Should().Be("Jane");
    }
}

