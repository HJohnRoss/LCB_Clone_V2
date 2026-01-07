using System.Net.Http.Json;
using FluentAssertions;
using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Dtos.Socials;
using LCB_Clone.Api.Tests.TestData.Legislators.Interfaces;
using LCB_Clone.Api.Tests.TestData.Socials.Interfaces;

namespace LCB_Clone.Api.Tests.TestData.Socials;

public sealed class SocialTestData(HttpClient client, ILegislatorTestData data) : ISocialTestData
{
	private readonly HttpClient _client = client;
	private readonly ILegislatorTestData _data = data;

	public async Task<SocialResponseDto> CreateSocialAsync()
	{
		LegislatorResponseDto legislator = await _data.CreateLegislatorAsync();

		const string testString = "Test String";

		var dto = new SocialCreateDto(
			testString,
			testString,
			legislator.Id
		);

		var response = await _client.PostAsJsonAsync("api/Social", dto);
		response.EnsureSuccessStatusCode();

		var created = await response.Content.ReadFromJsonAsync<SocialResponseDto>();
		created.Should().NotBeNull();

		return created;
	}
}
