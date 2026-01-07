using System.Net.Http.Json;
using FluentAssertions;
using LCB_Clone.Api.Tests.TestData.Legislators.Interfaces;
using LCB_Clone.Api.Tests.TestData.LegislatorStrings.Interfaces;
using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Tests.TestData.LegislatorStrings;

public sealed class LegislatorStringsTestData(HttpClient client, ILegislatorTestData data) : ILegislatorStringsTestData
{
	private readonly HttpClient _client = client;
	private readonly ILegislatorTestData _data = data;

	public async Task<LegislatorStringsResponseDto> CreateLegislatorStringAsync()
	{
		LegislatorResponseDto legislator = await _data.CreateLegislatorAsync();

		string testString = "testing String";
		LegislatorStringsCreateDto createDto = new(
				testString,
				Shared.Enums.Legislators.LegislatorStringType.LegService,
				legislator.Id
				);

		HttpResponseMessage response = await _client.PostAsJsonAsync("api/LegislatorString", createDto);
		response.EnsureSuccessStatusCode();

		LegislatorStringsResponseDto? created = await response.Content.ReadFromJsonAsync<LegislatorStringsResponseDto>();
		created.Should().NotBeNull();

		return created;
	}
}
