using System.Net.Http.Json;
using FluentAssertions;
using LCB_Clone.Api.Tests.TestData.Legislators.Interfaces;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Tests.TestData.Legislators;

public sealed class LegislatorTestData(HttpClient client) : ILegislatorTestData
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

}
