using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Tests.Features.Legislators;

public class CreateLegislatorTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
	private readonly HttpClient _client = factory.CreateClient();

	[Fact]
	public async Task CreateLegislator_Returns201AndLegislator()
	{
		string testString = "Test String";
		int testInt = 999;

		LegislatorCreateDto dto = new(
				testString,
				testString,
				testString,
				testString,
				testInt,
				testString,
				testInt,
				testInt,
				testString,
				testInt
				)
		{
			FirstName = testString,
			LastName = testString,
			Party = testString,
			County = testInt,
			Email = testString,
			TermEndYear = testInt
		};

		var response = await _client.PostAsJsonAsync("/api/Legislator", dto);

		response.StatusCode.Should().Be(HttpStatusCode.OK);

		LegislatorResponseDto? legislator =
			await response.Content.ReadFromJsonAsync<LegislatorResponseDto>();

		legislator.Should().BeEquivalentTo(dto, options =>
				options.ExcludingMissingMembers());
	}
}

