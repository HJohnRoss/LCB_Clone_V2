using LCB_Clone.Shared.Dtos.LegislatorStrings;
using LCB_Clone.Shared.Dtos.Socials;
using LCB_Clone.Shared.Enums.Chambers;

namespace LCB_Clone.Shared.Dtos.Legislators;

public class LegislatorRawDto(
		int id,
		string firstName,
		string? middleName,
		string lastName,
		string party,
		int county,
		string email,
		int? lvOffice,
		int? ccOffice,
		string? ccPhone,
		int termEndYear,
		Chamber chamber,
		List<SocialResponseDto> socials,
		List<LegislatorStringsResponseDto> legislatorStrings
		)
{
	public int Id { get; init; } = id;
	public string FirstName { get; init; } = firstName;
	public string? MiddleName { get; init; } = middleName;
	public string LastName { get; init; } = lastName;
	public string Party { get; init; } = party;
	public int County { get; init; } = county;
	public string Email { get; init; } = email;
	public int? LVOffice { get; init; } = lvOffice;
	public int? CCOffice { get; init; } = ccOffice;
	public string? CCPhone { get; init; } = ccPhone;
	public int TermEndYear { get; init; } = termEndYear;

	public Chamber Chamber { get; init; } = chamber;

	public List<SocialResponseDto> Socials { get; init; } = socials;
	public List<LegislatorStringsResponseDto> LegislatorStrings { get; init; } = legislatorStrings;
}
