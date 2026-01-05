using System.Net.Http.Json;
using FluentAssertions;
using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Tests.Features;

public sealed class TestData(HttpClient client)
{
	public async Task<LegislatorResponseDto> CreateLegislatorAsync()
	{
		const string testString = "Test String";
		const int testInt = 999;

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

		var response = await client.PostAsJsonAsync("api/Legislator", dto);
		response.EnsureSuccessStatusCode();

		var created = await response.Content.ReadFromJsonAsync<LegislatorResponseDto>();
		created.Should().NotBeNull();

		return created;
	}

	public async Task<SocialResponseDto> CreateSocialAsync()
	{
		var legislator = await CreateLegislatorAsync();

		const string testString = "Test String";

		var dto = new SocialCreateDto(
			testString,
			testString,
			legislator.Id
		);

		var response = await client.PostAsJsonAsync("api/Social", dto);
		response.EnsureSuccessStatusCode();

		var created = await response.Content.ReadFromJsonAsync<SocialResponseDto>();
		created.Should().NotBeNull();

		return created;
	}
}

