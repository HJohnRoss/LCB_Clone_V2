using LCB_Clone.Shared.Dtos.LegislatorStrings;
using LCB_Clone.Shared.Dtos.Socials;
using LCB_Clone.Shared.Enums.Chambers;

namespace LCB_Clone.Shared.Dtos.Legislators;

public class LegislatorResponseDto
{
	public int Id { get; init; }
	public string FirstName { get; init; } = string.Empty;
	public string? MiddleName { get; init; }
	public string LastName { get; init; } = string.Empty;
	public string Party { get; init; } = string.Empty;
	public int County { get; init; }
	public string Email { get; init; } = string.Empty;
	public int? LVOffice { get; init; }
	public int? CCOffice { get; init; }
	public string? CCPhone { get; init; }
	public int TermEndYear { get; init; }

	public Chamber Chamber { get; init; }

	public List<SocialResponseDto> Socials { get; init; } = [];

	public List<LegislatorStringsResponseDto> LegislatorStrings { get; init; } = [];

	public List<LegislatorStringsResponseDto> Affiliations { get; init; } = [];
	public List<LegislatorStringsResponseDto> Education { get; init; } = [];
	public List<LegislatorStringsResponseDto> HonorsRewards { get; init; } = [];
	public List<LegislatorStringsResponseDto> LegService { get; init; } = [];
	public List<LegislatorStringsResponseDto> MilitaryService { get; init; } = [];
	public List<LegislatorStringsResponseDto> OtherAchivements { get; init; } = [];
	public List<LegislatorStringsResponseDto> OtherPublicService { get; init; } = [];
	public List<LegislatorStringsResponseDto> Personal { get; init; } = [];
	public List<LegislatorStringsResponseDto> Proffesional { get; init; } = [];
}
